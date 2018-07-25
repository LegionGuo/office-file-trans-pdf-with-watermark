using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using WebApp;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApp
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebApp");

                        c.IncludeXmlComments(string.Format(@"{0}/bin/WebApp.XML", System.AppDomain.CurrentDomain.BaseDirectory));

                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
