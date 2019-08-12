namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataInDb : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE rides SET Driver_Id = NULL, Driver_Username = NULL, RideState = 0, Amount = 0 WHERE Id = 1;");
            Sql("UPDATE rides SET Driver_Id = NULL, Driver_Username = NULL, RideState = 4, Amount = 0 WHERE Id = 2;");
        }
        
        public override void Down()
        {
        }
    }
}
