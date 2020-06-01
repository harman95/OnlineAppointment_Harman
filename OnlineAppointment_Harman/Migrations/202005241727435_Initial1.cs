namespace OnlineAppointment_Harman.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "ServiceMst_ID", "dbo.ServiceMsts");
            DropForeignKey("dbo.Appointments", "SlotTimeMst_ID", "dbo.SlotTimeMsts");
            DropIndex("dbo.Appointments", new[] { "ServiceMst_ID" });
            DropIndex("dbo.Appointments", new[] { "SlotTimeMst_ID" });
            RenameColumn(table: "dbo.Appointments", name: "ServiceMst_ID", newName: "ServiceMstID");
            RenameColumn(table: "dbo.Appointments", name: "SlotTimeMst_ID", newName: "SlotTimeMstID");
            AlterColumn("dbo.Appointments", "ServiceMstID", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "SlotTimeMstID", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "ServiceMstID");
            CreateIndex("dbo.Appointments", "SlotTimeMstID");
            AddForeignKey("dbo.Appointments", "ServiceMstID", "dbo.ServiceMsts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "SlotTimeMstID", "dbo.SlotTimeMsts", "ID", cascadeDelete: true);
            DropColumn("dbo.Appointments", "ServiceID");
            DropColumn("dbo.Appointments", "SlotTimeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "SlotTimeID", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "ServiceID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "SlotTimeMstID", "dbo.SlotTimeMsts");
            DropForeignKey("dbo.Appointments", "ServiceMstID", "dbo.ServiceMsts");
            DropIndex("dbo.Appointments", new[] { "SlotTimeMstID" });
            DropIndex("dbo.Appointments", new[] { "ServiceMstID" });
            AlterColumn("dbo.Appointments", "SlotTimeMstID", c => c.Int());
            AlterColumn("dbo.Appointments", "ServiceMstID", c => c.Int());
            RenameColumn(table: "dbo.Appointments", name: "SlotTimeMstID", newName: "SlotTimeMst_ID");
            RenameColumn(table: "dbo.Appointments", name: "ServiceMstID", newName: "ServiceMst_ID");
            CreateIndex("dbo.Appointments", "SlotTimeMst_ID");
            CreateIndex("dbo.Appointments", "ServiceMst_ID");
            AddForeignKey("dbo.Appointments", "SlotTimeMst_ID", "dbo.SlotTimeMsts", "ID");
            AddForeignKey("dbo.Appointments", "ServiceMst_ID", "dbo.ServiceMsts", "ID");
        }
    }
}
