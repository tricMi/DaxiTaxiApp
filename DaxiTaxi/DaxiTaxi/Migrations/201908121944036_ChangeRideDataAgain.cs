namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRideDataAgain : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE rides SET RideState = 0 WHERE Id = 1;");

        }
        
        public override void Down()
        {
        }
    }
}
