namespace TennisOrganizer.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostAbstract : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gracze", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Gracze", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gracze", "City", c => c.String());
            AlterColumn("dbo.Gracze", "Email", c => c.String());
        }
    }
}
