namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVehicles : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE vehicles SET VehicleType = 2 WHERE Id = 1");
            Sql("UPDATE vehicles SET TaxiNumber = 2 WHERE Id = 5");
            
        }
        
        public override void Down()
        {
        }
    }
}
