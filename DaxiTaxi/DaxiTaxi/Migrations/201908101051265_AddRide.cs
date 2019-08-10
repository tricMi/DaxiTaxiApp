namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRide : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO rides(OrderDateTime, Amount, RideState, Comment_Id, Customer_Id, Customer_Username," +
               "CustomerLocation_Id, Destination_Id, Dispatcher_Id, Dispatcher_Username," +
               "Driver_Id, Driver_Username) VALUES ('2019-08-18 22:00:00', 0, 2, NULL, 3, 'sanja', 3, NULL, 1, 'pera', 11, 'joj')");

        }

        public override void Down()
        {
        }
    }
}
