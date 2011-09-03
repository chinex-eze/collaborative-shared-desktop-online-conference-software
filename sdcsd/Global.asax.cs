/***********************************************************************
 * Copyright (C) 2011 Ari Rokosa, Chinedu Eze, Johannes Virtanen,
 *                    Petri Tuononen, Timo Korkalainen
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 ***********************************************************************/
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

        void OnSessionStart()
        {
            Session["loggedin"] = "true";
            Session["user"] = "guest";
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