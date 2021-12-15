using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebExperience.Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}",
                                            new { id = RouteParameter.Optional }, null);
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            config.Routes.Add("DefaultApi", defaultRoute);
            //);
        }
    }
}
