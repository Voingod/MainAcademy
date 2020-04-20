using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hello_CodeFirst_MVC_my.Models
{
    public class PictureDbContext : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Description> Descriptions { get; set; }
    }
}