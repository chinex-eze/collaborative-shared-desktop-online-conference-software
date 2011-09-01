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
            //Database.SetInitializer(new DesktopItemDBInitializer());

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

    }

    //Execute this if DesktopItemDB database changes made
    public class DesktopItemDBInitializer : DropCreateDatabaseIfModelChanges<DesktopItemModelDBContext>
    {
        protected override void Seed(DesktopItemModelDBContext context)
        {
            base.Seed(context);

            context.DesktopItems.Add(new DesktopItemModel
            {
                ID = 1,
                DesktopID = 1,
                Name = "Minutes2010.txt",
                LocX = "10%",
                LocY = "25%"
            });

            context.DesktopItems.Add(new DesktopItemModel
            {
                ID = 2,
                DesktopID = 1,
                Name = "CorporateInfo.txt",
                LocX = "15%",
                LocY = "30%"
            });

            context.SaveChanges();
        }
    }
}