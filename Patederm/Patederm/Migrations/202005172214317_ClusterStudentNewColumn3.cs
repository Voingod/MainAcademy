namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClusterStudentNewColumn3 : DbMigration
    {
        public override void Up()
        {
            
            DropColumn("dbo.ClusterStudents", "NextClusterWomanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClusterStudents", "NextClusterWomanId", c => c.Byte(nullable: false));
        }
    }
}
