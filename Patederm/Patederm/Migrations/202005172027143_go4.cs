﻿namespace Patederm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Birthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.Students", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
