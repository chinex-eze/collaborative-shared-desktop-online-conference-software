using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace sdcsd.Models
{
    public class TopicModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }

    public class TopicDBContext : DbContext
    {
        public DbSet<TopicModel> Topics { get; set; }
    }
}