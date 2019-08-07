namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRides : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO rides(OrderDateTime, Amount, RideState, Comment_Id, Customer_Id, Customer_Username," +
                "CustomerLocation_Id, Destination_Id, Dispatcher_Id, Dispatcher_Username," +
                "Driver_Id, Driver_Username) VALUES ('2019-08-10 10:00:00', 200, 0, NULL, 1, 'pera', 1, NULL, NULL, NULL, NULL, NULL )");
        }
        
        public override void Down()
        {
        }
    }
}
