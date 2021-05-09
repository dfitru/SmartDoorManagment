namespace SmartDoor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Door", "BuildingId", c => c.Int());
            AddColumn("dbo.SmartKey", "Door_DoorId", c => c.Int());
            CreateIndex("dbo.Door", "BuildingId");
            CreateIndex("dbo.SmartKey", "Door_DoorId");
            AddForeignKey("dbo.Door", "BuildingId", "dbo.Building", "BuildingId");
            AddForeignKey("dbo.SmartKey", "Door_DoorId", "dbo.Door", "DoorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmartKey", "Door_DoorId", "dbo.Door");
            DropForeignKey("dbo.Door", "BuildingId", "dbo.Building");
            DropIndex("dbo.SmartKey", new[] { "Door_DoorId" });
            DropIndex("dbo.Door", new[] { "BuildingId" });
            DropColumn("dbo.SmartKey", "Door_DoorId");
            DropColumn("dbo.Door", "BuildingId");
        }
    }
}
