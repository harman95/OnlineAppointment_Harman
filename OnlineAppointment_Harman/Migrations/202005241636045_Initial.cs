namespace OnlineAppointment_Harman.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppoinntmentCancels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AppointmentID = c.Int(nullable: false),
                        CancelDate = c.DateTime(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Appointments", t => t.AppointmentID, cascadeDelete: true)
                .Index(t => t.AppointmentID);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SlotTimeID = c.Int(nullable: false),
                        Date = c.DateTime(),
                        ServiceMst_ID = c.Int(),
                        SlotTimeMst_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.ServiceMsts", t => t.ServiceMst_ID)
                .ForeignKey("dbo.SlotTimeMsts", t => t.SlotTimeMst_ID)
                .Index(t => t.CustomerID)
                .Index(t => t.ServiceMst_ID)
                .Index(t => t.SlotTimeMst_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProcessMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AppointmentID = c.Int(nullable: false),
                        ProcessDate = c.DateTime(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Appointments", t => t.AppointmentID, cascadeDelete: true)
                .Index(t => t.AppointmentID);
            
            CreateTable(
                "dbo.ServiceMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SlotTimeMsts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SlotDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Appointments", "SlotTimeMst_ID", "dbo.SlotTimeMsts");
            DropForeignKey("dbo.Appointments", "ServiceMst_ID", "dbo.ServiceMsts");
            DropForeignKey("dbo.ProcessMsts", "AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.AppoinntmentCancels", "AppointmentID", "dbo.Appointments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProcessMsts", new[] { "AppointmentID" });
            DropIndex("dbo.Appointments", new[] { "SlotTimeMst_ID" });
            DropIndex("dbo.Appointments", new[] { "ServiceMst_ID" });
            DropIndex("dbo.Appointments", new[] { "CustomerID" });
            DropIndex("dbo.AppoinntmentCancels", new[] { "AppointmentID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SlotTimeMsts");
            DropTable("dbo.ServiceMsts");
            DropTable("dbo.ProcessMsts");
            DropTable("dbo.Customers");
            DropTable("dbo.Appointments");
            DropTable("dbo.AppoinntmentCancels");
        }
    }
}
