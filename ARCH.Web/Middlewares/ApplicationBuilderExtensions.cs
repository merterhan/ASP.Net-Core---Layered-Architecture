using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace ARCH.Web.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Allow "node_modules" folder with wwwroot for static files
        /// </summary>
        /// <param name="app"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;
            app.UseStaticFiles(options);

            return app;
        }
    }
}
