using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ARCH.Business.Abstract;
using ARCH.Business.Concrete;
using ARCH.DataAccess.Abstract;
using ARCH.DataAccess.Concrete.EntityFramework;
using ARCH.Web.Entities;
using ARCH.Web.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARCH.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //servis yapılandırmaları yapılır. servis bağımlıllıkları buraya eklenir.
            //controller'ın ihtiyaç duyduğu servisler burada gerçekleştirilir.
            //dependency injection burada gerçekleştiriliyor.

            services.AddDbContext<ARCHContext>();
            //Localization
            services.AddLocalization(o => o.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //dependency injection desenini yapılandıralım. servisleri buraya ekleyeceğiz.
            //IXXservice isteyen bir controller varsa ona XXManager örneği oluştur ona ver. sen new'le.
            services.AddScoped<IDepartmentService, DepartmantManager>();
            services.AddScoped<IDepartmentDal, EFDepartmentDal>();

            //servisler transient, scoped veya singleton olabilir. 
            //servisler singleton olarak tanımlansaydı: iki kullanıcı sunucuya istek bulunduğu zaman manager örneği oluşturur.
            //b kullanıcısı da aynı nesneyi kullanır. her kullanıcı bu tanımlanan singleton nesneyi oluşturur.

            //scoped: A kullanıcısı XXManager'a istekte bulunduğunda bir xxManager nesnesi oluşur. A kullanıcısı 2. istek yaptığında bir xxManager nesnesi daha oluşur.
            // nesne örnekleri yapılan her istekte yeniden oluşur. transientte de bu durum böyle fakat

            //transient: A kullanıcısı aynı anda iki XXManager'a ihtiyaç duyarsa.Onun için aynı XXManager oluşturuluğ değiştirilir.
            //Transient'te aynı kullanıcı aynı anda tek requestte iki XXManager'a ihtiyaç duyarsa iki ayrı PM Oluşturulur.


            //uygulamada session kullanacağımız bilgisini oluşturalum
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddSingleton<ISessionService, SessionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("infoline-10.1.1.78")));
            services.AddDbContext<CustomIdentityDbContext>(options => options.UseMySql(Configuration.GetConnectionString("cagrierhan.com/cagrierh_coredb")));

            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders(); //kullanıcı bilgilerinin sayfalar arası geçiş yaparken kullandığı bir servis

            services.Configure<IdentityOptions>(options =>
            {

                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //loglama,exception middleware olayları bu kısımda belirtilir.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //Localization
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("tr-TR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                //TODO RequestCultureProviders çalışıyor mu kontrol edilecek
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new CustomRequestCultureProvider(async context =>
                    {
                        return new ProviderCultureResult("tr-TR");
                    }),
                    new CustomRequestCultureProvider(async context =>
                    {
                        return new ProviderCultureResult("en-US");
                    }),

                }
            });
            //end_Localization
            app.UseSession();
            //session orta-katmanını projeye ekleyelim
            //aspnet identity middleware'inin eklenmesi
            app.UseAuthentication();

            //default olarak Home/Index'e gider
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
