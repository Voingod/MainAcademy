namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClusterStudentNewColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClusterStudents", "NextClusterWomanId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClusterStudents", "NextClusterWomanId");
        }
    }
}
