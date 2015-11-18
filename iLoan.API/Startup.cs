using System.IO;
using System.Net.NetworkInformation;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Owin;
using Microsoft.Owin.FileSystems;

namespace iLoan.API
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "iLoanApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true,
                DefaultFilesOptions = { DefaultFileNames = { "index.html" } },
                FileSystem = new PhysicalFileSystem("public")
            };

            appBuilder.UseFileServer(options);
            appBuilder.UseWebApi(config);
        }
    }
}
