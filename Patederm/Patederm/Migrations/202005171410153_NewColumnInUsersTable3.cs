namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnInUsersTable3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CardioParams", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ClusterStudents", "StudentId", "dbo.Students");
            DropIndex("dbo.CardioParams", new[] { "StudentId" });
            DropIndex("dbo.ClusterStudents", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.CardioParams", "Student_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.ClusterStudents", "Student_UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Students", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Students", "UserId");
            CreateIndex("dbo.CardioParams", "Student_UserId");
            CreateIndex("dbo.ClusterStudents", "Student_UserId");
            CreateIndex("dbo.Students", "UserId");
            AddForeignKey("dbo.CardioParams", "Student_UserId", "dbo.Students", "UserId");
            AddForeignKey("dbo.ClusterStudents", "Student_UserId", "dbo.Students", "UserId");
            DropColumn("dbo.Students", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ClusterStudents", "Student_UserId", "dbo.Students");
            DropForeignKey("dbo.CardioParams", "Student_UserId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.ClusterStudents", new[] { "Student_UserId" });
            DropIndex("dbo.CardioParams", new[] { "Student_UserId" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.ClusterStudents", "Student_UserId");
            DropColumn("dbo.CardioParams", "Student_UserId");
            AddPrimaryKey("dbo.Students", "Id");
            CreateIndex("dbo.Students", "UserId");
            CreateIndex("dbo.ClusterStudents", "StudentId");
            CreateIndex("dbo.CardioParams", "StudentId");
            AddForeignKey("dbo.ClusterStudents", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CardioParams", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
