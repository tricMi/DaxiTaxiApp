namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineMg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        StreetNumber = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        CallNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, unicode: false),
                        PublishDate = c.DateTime(nullable: false, precision: 0),
                        Rate = c.Int(nullable: false),
                        UserThatLeftComment_Id = c.Int(nullable: false),
                        UserThatLeftComment_Username = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => new { t.UserThatLeftComment_Id, t.UserThatLeftComment_Username }, cascadeDelete: true)
                .Index(t => new { t.UserThatLeftComment_Id, t.UserThatLeftComment_Username });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Surname = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Gender = c.Int(nullable: false),
                        JMBG = c.String(nullable: false, maxLength: 13, storeType: "nvarchar"),
                        PhoneNumber = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        Role = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id, t.Username })
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        XCoordinate = c.Double(nullable: false),
                        YCoordinate = c.Double(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDateTime = c.DateTime(nullable: false, precision: 0),
                        Amount = c.Double(nullable: false),
                        RideState = c.Int(nullable: false),
                        Comment_Id = c.Int(),
                        Customer_Id = c.Int(nullable: false),
                        Customer_Username = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        CustomerLocation_Id = c.Int(nullable: false),
                        Destination_Id = c.Int(),
                        Dispatcher_Id = c.Int(),
                        Dispatcher_Username = c.String(maxLength: 30, storeType: "nvarchar"),
                        Driver_Id = c.Int(),
                        Driver_Username = c.String(maxLength: 30, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .ForeignKey("dbo.Users", t => new { t.Customer_Id, t.Customer_Username }, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.CustomerLocation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Destination_Id)
                .ForeignKey("dbo.Users", t => new { t.Dispatcher_Id, t.Dispatcher_Username })
                .ForeignKey("dbo.Users", t => new { t.Driver_Id, t.Driver_Username })
                .Index(t => t.Comment_Id)
                .Index(t => new { t.Customer_Id, t.Customer_Username })
                .Index(t => t.CustomerLocation_Id)
                .Index(t => t.Destination_Id)
                .Index(t => new { t.Dispatcher_Id, t.Dispatcher_Username })
                .Index(t => new { t.Driver_Id, t.Driver_Username });
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaxiNumber = c.Int(nullable: false),
                        VehicleYear = c.Int(nullable: false),
                        RegistrationNumber = c.String(nullable: false, unicode: false),
                        VehicleType = c.Int(nullable: false),
                        Driver_Id = c.Int(nullable: false),
                        Driver_Username = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.Id, t.TaxiNumber })
                .ForeignKey("dbo.Users", t => new { t.Driver_Id, t.Driver_Username }, cascadeDelete: true)
                .Index(t => new { t.Driver_Id, t.Driver_Username });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", new[] { "Driver_Id", "Driver_Username" }, "dbo.Users");
            DropForeignKey("dbo.Rides", new[] { "Driver_Id", "Driver_Username" }, "dbo.Users");
            DropForeignKey("dbo.Rides", new[] { "Dispatcher_Id", "Dispatcher_Username" }, "dbo.Users");
            DropForeignKey("dbo.Rides", "Destination_Id", "dbo.Locations");
            DropForeignKey("dbo.Rides", "CustomerLocation_Id", "dbo.Locations");
            DropForeignKey("dbo.Rides", new[] { "Customer_Id", "Customer_Username" }, "dbo.Users");
            DropForeignKey("dbo.Rides", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", new[] { "UserThatLeftComment_Id", "UserThatLeftComment_Username" }, "dbo.Users");
            DropForeignKey("dbo.Users", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Vehicles", new[] { "Driver_Id", "Driver_Username" });
            DropIndex("dbo.Rides", new[] { "Driver_Id", "Driver_Username" });
            DropIndex("dbo.Rides", new[] { "Dispatcher_Id", "Dispatcher_Username" });
            DropIndex("dbo.Rides", new[] { "Destination_Id" });
            DropIndex("dbo.Rides", new[] { "CustomerLocation_Id" });
            DropIndex("dbo.Rides", new[] { "Customer_Id", "Customer_Username" });
            DropIndex("dbo.Rides", new[] { "Comment_Id" });
            DropIndex("dbo.Locations", new[] { "Address_Id" });
            DropIndex("dbo.Users", new[] { "Location_Id" });
            DropIndex("dbo.Comments", new[] { "UserThatLeftComment_Id", "UserThatLeftComment_Username" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Rides");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Addresses");
        }
    }
}
