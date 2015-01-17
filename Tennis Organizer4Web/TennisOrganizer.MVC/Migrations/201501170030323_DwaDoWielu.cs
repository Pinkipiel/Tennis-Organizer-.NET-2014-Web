namespace TennisOrganizer.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DwaDoWielu : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pojedynki", new[] { "GuestPlayer_AccountId" });
            DropIndex("dbo.Pojedynki", new[] { "HomePlayer_AccountId" });
            DropColumn("dbo.Pojedynki", "GuestPlayerId");
            DropColumn("dbo.Pojedynki", "HomePlayerId");
            RenameColumn(table: "dbo.Pojedynki", name: "GuestPlayer_AccountId", newName: "GuestPlayerId");
            RenameColumn(table: "dbo.Pojedynki", name: "HomePlayer_AccountId", newName: "HomePlayerId");
            AlterColumn("dbo.Pojedynki", "GuestPlayerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pojedynki", "HomePlayerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pojedynki", "HomePlayerId");
            CreateIndex("dbo.Pojedynki", "GuestPlayerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pojedynki", new[] { "GuestPlayerId" });
            DropIndex("dbo.Pojedynki", new[] { "HomePlayerId" });
            AlterColumn("dbo.Pojedynki", "HomePlayerId", c => c.Int());
            AlterColumn("dbo.Pojedynki", "GuestPlayerId", c => c.Int());
            RenameColumn(table: "dbo.Pojedynki", name: "HomePlayerId", newName: "HomePlayer_AccountId");
            RenameColumn(table: "dbo.Pojedynki", name: "GuestPlayerId", newName: "GuestPlayer_AccountId");
            AddColumn("dbo.Pojedynki", "HomePlayerId", c => c.Int(nullable: false));
            AddColumn("dbo.Pojedynki", "GuestPlayerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pojedynki", "HomePlayer_AccountId");
            CreateIndex("dbo.Pojedynki", "GuestPlayer_AccountId");
        }
    }
}
