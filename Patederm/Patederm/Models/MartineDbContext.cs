using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Patederm.Models
{
    public class MartineDbContext : IdentityDbContext<AppUser>
    {
        public MartineDbContext() : base("MartineDbConnection")
        {

        }
        public static MartineDbContext Create()
        {
            return new MartineDbContext();
        }
        public DbSet<CardioParam> CardioParams { get; set; }
        public DbSet<CardioParamResultWoman> CardioParamResultWomen { get; set; }
        public DbSet<ClusterStudent> ClusterStudents { get; set; }
        public DbSet<ClusterWoman> ClusterWomen { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TypeOfSport> TypeOfSports { get; set; }

    }


}