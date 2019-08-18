namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSomeDataInDb : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Rides SET RideState = 0 WHERE Id = 16");
            Sql("UPDATE Rides SET RideState = 0 WHERE Id = 17");
            Sql("DELETE FROM Addresses WHERE Id = 16");
            Sql("DELETE FROM Locations WHERE Id = 16");
            Sql("DELETE FROM Comments WHERE Id = 4");
            Sql("DELETE FROM Comments WHERE Id = 6");
            Sql("DELETE FROM Rides WHERE Id = 16");

        }
        
        public override void Down()
        {
        }
    }
}
