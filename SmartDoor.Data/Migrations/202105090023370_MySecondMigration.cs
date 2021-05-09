namespace SmartDoor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MySecondMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SmartKey", name: "Door_DoorId", newName: "DoorId");
            RenameIndex(table: "dbo.SmartKey", name: "IX_Door_DoorId", newName: "IX_DoorId");
            AddColumn("dbo.SmartKey", "PersonId", c => c.Int());
            AlterColumn("dbo.SmartKey", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.SmartKey", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.SmartKey", "PersonId");
            AddForeignKey("dbo.SmartKey", "PersonId", "dbo.Person", "PersonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmartKey", "PersonId", "dbo.Person");
            DropIndex("dbo.SmartKey", new[] { "PersonId" });
            AlterColumn("dbo.SmartKey", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SmartKey", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SmartKey", "PersonId");
            RenameIndex(table: "dbo.SmartKey", name: "IX_DoorId", newName: "IX_Door_DoorId");
            RenameColumn(table: "dbo.SmartKey", name: "DoorId", newName: "Door_DoorId");
        }
    }
}
