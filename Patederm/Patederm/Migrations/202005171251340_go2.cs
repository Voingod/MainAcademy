namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "FirstName1");
        }
    }
}
