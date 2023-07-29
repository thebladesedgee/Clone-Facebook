using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace facebook.Models.Context
{
    public class DatabaseContext:DbContext
    {
        public DbSet<KişiselDatalar> data { get; set; }
    }
}