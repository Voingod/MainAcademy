namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newRow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CardioParams", "ClusterStudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CardioParams", "ClusterStudentId");
            AddForeignKey("dbo.CardioParams", "ClusterStudentId", "dbo.ClusterStudents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardioParams", "ClusterStudentId", "dbo.ClusterStudents");
            DropIndex("dbo.CardioParams", new[] { "ClusterStudentId" });
            DropColumn("dbo.CardioParams", "ClusterStudentId");
        }
    }
}
