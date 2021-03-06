﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Handin3_2
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

            HttpConfiguration config = GlobalConfiguration.Configuration;

            ////Det frembringer et ID til krydsreferencer, derfor skal man bruge DTO, brug dette hvis man er doven og ikke gider at lave DTOer
            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.All;
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            //    = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            //    = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
            //    = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            //xml.UseXmlSerializer = true;

        }
    }
}
