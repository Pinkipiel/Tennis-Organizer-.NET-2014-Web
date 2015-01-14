namespace TennisOrganizer.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Konta",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Gracze",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        SkillLevel = c.Single(nullable: false),
                        ImagePath = c.String(),
                        City = c.String(),
                        TopPosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Konta", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Pojedynki",
                c => new
                    {
                        DuelId = c.Int(nullable: false, identity: true),
                        DateOfPlay = c.DateTime(nullable: false),
                        Accepted = c.Boolean(),
                        Seen = c.Boolean(nullable: false),
                        Result = c.String(),
                        HomePlayerId = c.Int(nullable: false),
                        GuestPlayerId = c.Int(nullable: false),
                        GuestPlayer_AccountId = c.Int(),
                        HomePlayer_AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.DuelId)
                .ForeignKey("dbo.Gracze", t => t.GuestPlayer_AccountId)
                .ForeignKey("dbo.Gracze", t => t.HomePlayer_AccountId)
                .Index(t => t.GuestPlayer_AccountId)
                .Index(t => t.HomePlayer_AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pojedynki", "HomePlayer_AccountId", "dbo.Gracze");
            DropForeignKey("dbo.Pojedynki", "GuestPlayer_AccountId", "dbo.Gracze");
            DropForeignKey("dbo.Gracze", "AccountId", "dbo.Konta");
            DropIndex("dbo.Pojedynki", new[] { "HomePlayer_AccountId" });
            DropIndex("dbo.Pojedynki", new[] { "GuestPlayer_AccountId" });
            DropIndex("dbo.Gracze", new[] { "AccountId" });
            DropTable("dbo.Pojedynki");
            DropTable("dbo.Gracze");
            DropTable("dbo.Konta");
        }
    }
}
