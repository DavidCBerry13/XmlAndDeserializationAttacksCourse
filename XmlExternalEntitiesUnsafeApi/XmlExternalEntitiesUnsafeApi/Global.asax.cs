using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml.Serialization;
using XmlExternalEntitiesUnsafeApi.ApiModels;

namespace XmlExternalEntitiesUnsafeApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig.Config();


            // Telling WebAPI to use the XmlSerializer and correcting the root element for the List
            GlobalConfiguration.Configuration.Formatters.XmlFormatter
                .SetSerializer<List<OrderModel>>(new XmlSerializer(typeof(List<OrderModel>), new XmlRootAttribute("orders")));
            GlobalConfiguration.Configuration.Formatters.XmlFormatter
                .SetSerializer<OrderModel>(new XmlSerializer(typeof(OrderModel)));
        }
    }
}
