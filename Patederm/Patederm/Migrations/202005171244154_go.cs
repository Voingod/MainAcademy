namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.CardioParamResultWomen",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ClusterWomanId = c.Byte(nullable: false),
            //            ASP = c.Double(nullable: false),
            //            ADP = c.Double(nullable: false),
            //            HR = c.Double(nullable: false),
            //            Minute = c.Byte(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.ClusterWomen", t => t.ClusterWomanId, cascadeDelete: true)
            //    .Index(t => t.ClusterWomanId);
            
            //CreateTable(
            //    "dbo.CardioParams",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            StudentId = c.Int(nullable: false),
            //            ASP = c.Double(nullable: false),
            //            ADP = c.Double(nullable: false),
            //            HR = c.Double(nullable: false),
            //            Minute = c.Byte(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
            //    .Index(t => t.StudentId);
            
            //CreateTable(
            //    "dbo.ClusterStudents",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ClusterWomanId = c.Byte(nullable: false),
            //            StudentId = c.Int(nullable: false),
            //            Dist = c.Double(nullable: false),
            //            NextDist = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.ClusterWomen", t => t.ClusterWomanId, cascadeDelete: true)
            //    .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
            //    .Index(t => t.ClusterWomanId)
            //    .Index(t => t.StudentId);
            
            //CreateTable(
            //    "dbo.ClusterWomen",
            //    c => new
            //        {
            //            Id = c.Byte(nullable: false),
            //            Cluster = c.Byte(nullable: false),
            //            Conclusion = c.String(),
            //            Recomendation = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Departments",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            DepartmentName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Students",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            DepartmentId = c.Int(nullable: false),
            //            TypeOfSportId = c.Int(nullable: false),
            //            FirstName = c.String(),
            //            SecondName = c.String(),
            //            Surname = c.String(),
            //            Course = c.Byte(nullable: false),
            //            Course2 = c.Byte(nullable: false),
            //            Birthday = c.DateTime(nullable: false),
            //            Sex = c.Byte(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
            //    .ForeignKey("dbo.TypeOfSports", t => t.TypeOfSportId, cascadeDelete: true)
            //    .Index(t => t.DepartmentId)
            //    .Index(t => t.TypeOfSportId);
            
            //CreateTable(
            //    "dbo.TypeOfSports",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            TypeOfSportName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "TypeOfSportId", "dbo.TypeOfSports");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ClusterStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CardioParams", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ClusterStudents", "ClusterWomanId", "dbo.ClusterWomen");
            DropForeignKey("dbo.CardioParamResultWomen", "ClusterWomanId", "dbo.ClusterWomen");
            DropIndex("dbo.Students", new[] { "TypeOfSportId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.ClusterStudents", new[] { "StudentId" });
            DropIndex("dbo.ClusterStudents", new[] { "ClusterWomanId" });
            DropIndex("dbo.CardioParams", new[] { "StudentId" });
            DropIndex("dbo.CardioParamResultWomen", new[] { "ClusterWomanId" });
            DropTable("dbo.TypeOfSports");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
            DropTable("dbo.ClusterWomen");
            DropTable("dbo.ClusterStudents");
            DropTable("dbo.CardioParams");
            DropTable("dbo.CardioParamResultWomen");
        }
    }
}
