namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreLocations : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO addresses(Street, StreetNumber, City, CallNumber) VALUES ('Bulevar Jase Tomica', 4, 'Novi Sad', 21000)");
            Sql("INSERT INTO addresses(Street, StreetNumber, City, CallNumber) VALUES ('Lasla Gala', 23, 'Novi Sad', 409848)");
            Sql("INSERT INTO addresses(Street, StreetNumber, City, CallNumber) VALUES ('Kopernikova', 39, 'Novi Sad', 21000)");
            Sql("INSERT INTO addresses(Street, StreetNumber, City, CallNumber) VALUES ('Petra Kocica', 15, 'Novi Sad', 21000)");

            Sql("INSERT INTO locations(XCoordinate, YCoordinate, Address_Id) VALUES (45.265871, 19.829365, 4)");
            Sql("INSERT INTO locations(XCoordinate, YCoordinate, Address_Id) VALUES (45.245703, 19.837247, 5)");
            Sql("INSERT INTO locations(XCoordinate, YCoordinate, Address_Id) VALUES (45.256111, 19.816219, 6)");
            Sql("INSERT INTO locations(XCoordinate, YCoordinate, Address_Id) VALUES (45.261765, 19.845595, 7)");
        }
        
        public override void Down()
        {
        }
    }
}
