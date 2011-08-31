using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdcsd.Models
{
    public class DesktopItemModel
    {
        public int ID { get; set; }
        public int DesktopID { get; set; }
        public String Name { get; set; }
        public String LocX { get; set; }
        public String LocY { get; set; }
    }
}