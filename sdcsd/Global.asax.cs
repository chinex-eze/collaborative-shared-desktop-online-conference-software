using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using sdcsd.Models;

namespace sdcsd
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            Database.SetInitializer(new DesktopDBInitializer());

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }

    public class DesktopDBInitializer : DropCreateDatabaseIfModelChanges<DesktopDB>
    {
        protected override void Seed(DesktopDB context)
        {
            base.Seed(context);

            context.DesktopModels.Add(new DesktopModel
            {
                ID = 1,
                Name = "Minutes2010.txt",
                Icon = "/../../Content/icons/48px_txt.png",
                Type = "txt",
                LocX = "100px",
                LocY = "250px"
            });

            context.DesktopModels.Add(new DesktopModel
            {
                ID = 2,
                Name = "CorporateInfo.txt",
                Icon = "/../../Content/icons/48px_document.png",
                Type = "document",
                LocX = "150px",
                LocY = "300px"
            });

            context.SaveChanges();
        }
    }
}