namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "FirstName1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FirstName1", c => c.String());
        }
    }
}
