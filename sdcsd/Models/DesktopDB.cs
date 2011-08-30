using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace sdcsd.Models
{
    public class DesktopDB : DbContext
    {
        public DbSet<DesktopModel> DesktopModels { get; set; }   
    }
}