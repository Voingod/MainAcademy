namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnInUsersTable4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CardioParams", name: "Student_UserId", newName: "Student_Id");
            RenameColumn(table: "dbo.ClusterStudents", name: "Student_UserId", newName: "Student_Id");
            RenameColumn(table: "dbo.Students", name: "UserId", newName: "Id");
            RenameIndex(table: "dbo.CardioParams", name: "IX_Student_UserId", newName: "IX_Student_Id");
            RenameIndex(table: "dbo.ClusterStudents", name: "IX_Student_UserId", newName: "IX_Student_Id");
            RenameIndex(table: "dbo.Students", name: "IX_UserId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.ClusterStudents", name: "IX_Student_Id", newName: "IX_Student_UserId");
            RenameIndex(table: "dbo.CardioParams", name: "IX_Student_Id", newName: "IX_Student_UserId");
            RenameColumn(table: "dbo.Students", name: "Id", newName: "UserId");
            RenameColumn(table: "dbo.ClusterStudents", name: "Student_Id", newName: "Student_UserId");
            RenameColumn(table: "dbo.CardioParams", name: "Student_Id", newName: "Student_UserId");
        }
    }
}
