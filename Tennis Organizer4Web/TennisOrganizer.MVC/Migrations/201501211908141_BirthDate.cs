namespace TennisOrganizer.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gracze", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Gracze", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gracze", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Gracze", "BirthDate");
        }
    }
}
