namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnInUsersTable5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CardioParams", new[] { "Student_Id" });
            DropIndex("dbo.ClusterStudents", new[] { "Student_Id" });
            DropColumn("dbo.CardioParams", "StudentId");
            DropColumn("dbo.ClusterStudents", "StudentId");
            RenameColumn(table: "dbo.CardioParams", name: "Student_Id", newName: "StudentId");
            RenameColumn(table: "dbo.ClusterStudents", name: "Student_Id", newName: "StudentId");
            AlterColumn("dbo.CardioParams", "StudentId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ClusterStudents", "StudentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CardioParams", "StudentId");
            CreateIndex("dbo.ClusterStudents", "StudentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClusterStudents", new[] { "StudentId" });
            DropIndex("dbo.CardioParams", new[] { "StudentId" });
            AlterColumn("dbo.ClusterStudents", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.CardioParams", "StudentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ClusterStudents", name: "StudentId", newName: "Student_Id");
            RenameColumn(table: "dbo.CardioParams", name: "StudentId", newName: "Student_Id");
            AddColumn("dbo.ClusterStudents", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.CardioParams", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClusterStudents", "Student_Id");
            CreateIndex("dbo.CardioParams", "Student_Id");
        }
    }
}
