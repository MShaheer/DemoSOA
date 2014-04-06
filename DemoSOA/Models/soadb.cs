using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoSOA.Models
{
    public class soadb : DbContext
    {

        public DbSet<billmaster> billsmaster { get; set; }
        public DbSet<billdetail> billsdetail { get; set; }
    }
}