
using Common.ExceptionManagerApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace OnlineShoppingAPIService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //.Services.Add(typeof(IExceptionLogger), new ExceptionManagerApi());
            config.Services.Add(typeof(IExceptionLogger), new ExceptionManagerApi());

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                //defaults: new { controller = "Product", action = "GetProductByCategoryID", id = RouteParameter.Optional }
            );
        }
    }
}
