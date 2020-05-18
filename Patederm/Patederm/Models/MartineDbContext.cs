using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Patederm.Models
{
    public class MartineDbContext : IdentityDbContext<AppUser>
    {
        static MartineDbContext()
        {
            Database.SetInitializer(new MartineDbContextInitializer());
        }
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // every property of type DateTime should have a column type of "datetime2":
            modelBuilder.Properties<DateTime>()
              .Configure(property => property.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }
    }

    class MartineDbContextInitializer : CreateDatabaseIfNotExists<MartineDbContext>
    {
        protected override void Seed(MartineDbContext db)
        {
            db.Departments.Add(new Department { DepartmentName = "None" });
            db.TypeOfSports.Add(new TypeOfSport { TypeOfSportName = "None" });
            db.SaveChanges();
        }
    }
}