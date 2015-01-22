namespace TennisOrganizer.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trainers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gracze", "Description", c => c.String());
            AddColumn("dbo.Gracze", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gracze", "Discriminator");
            DropColumn("dbo.Gracze", "Description");
        }
    }
}
