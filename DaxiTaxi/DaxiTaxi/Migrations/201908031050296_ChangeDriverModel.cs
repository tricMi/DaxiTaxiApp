namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDriverModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("vehicles", new[] { "Driver_Id", "Driver_Username" }, "users");
            DropIndex("vehicles", new[] { "Driver_Id", "Driver_Username" });
            AddColumn("users", "Vehicle_Id", c => c.Int());
            AddColumn("users", "Vehicle_TaxiNumber", c => c.Int());
            CreateIndex("users", new[] { "Vehicle_Id", "Vehicle_TaxiNumber" });
            AddForeignKey("users", new[] { "Vehicle_Id", "Vehicle_TaxiNumber" }, "vehicles", new[] { "Id", "TaxiNumber" });
            DropColumn("vehicles", "Driver_Id");
            DropColumn("vehicles", "Driver_Username");
        }
        
        public override void Down()
        {
            AddColumn("vehicles", "Driver_Username", c => c.String(nullable: false, maxLength: 30, storeType: "nvarchar"));
            AddColumn("vehicles", "Driver_Id", c => c.Int(nullable: false));
            DropForeignKey("users", new[] { "Vehicle_Id", "Vehicle_TaxiNumber" }, "vehicles");
            DropIndex("users", new[] { "Vehicle_Id", "Vehicle_TaxiNumber" });
            DropColumn("users", "Vehicle_TaxiNumber");
            DropColumn("users", "Vehicle_Id");
            CreateIndex("Vehicles", new[] { "Driver_Id", "Driver_Username" });
            AddForeignKey("vehicles", new[] { "Driver_Id", "Driver_Username" }, "Users", new[] { "Id", "Username" }, cascadeDelete: true);
        }
    }
}
