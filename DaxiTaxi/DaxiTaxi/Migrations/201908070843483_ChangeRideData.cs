namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRideData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE rides SET Customer_Id = 3, Customer_Username = 'sanja' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
