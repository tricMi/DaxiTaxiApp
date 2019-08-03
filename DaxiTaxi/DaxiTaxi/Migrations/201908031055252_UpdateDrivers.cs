namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDrivers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE users SET Vehicle_Id = 1, Vehicle_TaxiNumber = '23' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
