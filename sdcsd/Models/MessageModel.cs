using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace sdcsd.Models
{
    public class MessageModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime TimeSent { get; set; }
    }

    public class MessageDBContext : DbContext
    {
        public DbSet<MessageModel> Messages { get; set; }
    }
}