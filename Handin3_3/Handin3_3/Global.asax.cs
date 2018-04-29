using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Handin3_3.Models;

namespace Handin3_3
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

            //Initialisering af klasserne
            //DocumentDBRepository<PersonSimpleDTO>.Initialize();
            //DocumentDBRepository<PersonDetailDTO>.Initialize();
            DocumentDBRepository<ContactsDTO>.Initialize();
            DocumentDBRepository<PersonDTO>.Initialize();
            DocumentDBRepository<Persons>.Initialize();
            DocumentDBRepository<Cities>.Initialize();
            DocumentDBRepository<Contacts>.Initialize();
            DocumentDBRepository<Phones>.Initialize();
            DocumentDBRepository<Addresses>.Initialize();
            DocumentDBRepository<AltAddresses>.Initialize();
        }
    }
}
