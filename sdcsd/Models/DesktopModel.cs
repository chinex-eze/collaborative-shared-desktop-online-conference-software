using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdcsd.Models
{
    public class DesktopModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Icon { get; set; }
        public String Type { get; set; }
        public int LocX { get; set; }
        public int LocY { get; set; }
        //public bool Hide { get; set; }
    }
}