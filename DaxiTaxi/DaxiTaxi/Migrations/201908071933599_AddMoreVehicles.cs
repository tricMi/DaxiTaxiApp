namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreVehicles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (17, 2012, 'NS-235-34', 3)");
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (234, 2011, 'NS-145-434', 2)");
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (17, 2012, 'NS-443-666', 3)");
        }
        
        public override void Down()
        {
        }
    }
}
