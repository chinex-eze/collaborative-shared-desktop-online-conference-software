using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace sdcsd.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime LastSeen { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public DbSet<UserModel> UsersDB { get; set; }
    }
}