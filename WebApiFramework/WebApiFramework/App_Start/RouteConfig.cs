

using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Routing;

namespace WebApiFramework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "swagger", 
                routeTemplate: "",
                defaults: null, 
                constraints: null,
                handler: new RedirectHandler((url => url.RequestUri.ToString()), "swagger")
            );
        }
    }
}