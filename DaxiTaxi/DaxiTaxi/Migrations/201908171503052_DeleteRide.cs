namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRide : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Rides WHERE Id = 6");
        }
        
        public override void Down()
        {
        }
    }
}
