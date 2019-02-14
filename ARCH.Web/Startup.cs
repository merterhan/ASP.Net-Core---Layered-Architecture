using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARCH.Business.Abstract;
using ARCH.Business.Concrete;
using ARCH.DataAccess.Abstract;
using ARCH.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            services.AddMvc();

            //dependency injection desenini yapılandıralım. servisleri buraya ekleyeceğiz.
            //IXXservice isteyen bir controller varsa ona XXManager örneği oluştur ona ver. sen new'le.
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EFUserDal>();

            //servisler transient, scoped veya singleton olabilir. 
            //servisler singleton olarak tanımlansaydı: iki kullanıcı sunucuya istek bulunduğu zaman manager örneği oluşturur.
            //b kullanıcısı da aynı nesneyi kullanır. her kullanıcı bu tanımlanan singleton nesneyi oluşturur.

            //scoped: A kullanıcısı XXManager'a istekte bulunduğunda bir xxManager nesnesi oluşur. A kullanıcısı 2. istek yaptığında bir xxManager nesnesi daha oluşur.
            // nesne örnekleri yapılan her istekte yeniden oluşur. transientte de bu durum böyle fakat

            //transient: A kullanıcısı aynı anda iki XXManager'a ihtiyaç duyarsa.Onun için aynı XXManager oluşturuluğ değiştirilir.
            //Transient'te aynı kullanıcı aynı anda tek requestte iki XXManager'a ihtiyaç duyarsa iki ayrı PM Oluşturulur.
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

            //default olarak Home/Index'e gider
            //app.UseMvcWithDefaultRoute();

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
