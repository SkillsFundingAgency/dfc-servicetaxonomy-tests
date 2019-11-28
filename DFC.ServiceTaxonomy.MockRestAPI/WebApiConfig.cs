using System.Web;
using System.Web.Http;

namespace DFC.ServiceTaxonomy.MockRestAPI
{
    class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}

    
