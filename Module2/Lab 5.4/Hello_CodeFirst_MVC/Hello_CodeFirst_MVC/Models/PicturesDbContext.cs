using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Hello_CodeFirst_MVC.Models
{
    public class PicturesDbContext : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Description> Descriptions { get; set; }
    }
}