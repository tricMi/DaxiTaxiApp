namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertFormedRide : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO rides(OrderDateTime, Amount, RideState, Comment_Id, Customer_Id, Customer_Username," +
              "CustomerLocation_Id, Destination_Id, Dispatcher_Id, Dispatcher_Username," +
              "Driver_Id, Driver_Username) VALUES ('2019-08-20 20:00:00', 0, 1, NULL, NULL, NULL, 2, NULL, 4, 'alex', 1, 'pera')");
        }
        
        public override void Down()
        {
        }
    }
}
