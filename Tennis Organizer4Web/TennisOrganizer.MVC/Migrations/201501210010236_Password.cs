namespace TennisOrganizer.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Password : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Konta", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Konta", "Password", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
