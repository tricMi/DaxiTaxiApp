namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreDrivers1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (4893, 2011, 'NS-3522-344', 2)");
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (445, 2009, 'NS-553-532', 1)");
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (3214, 2018, 'NS-321-342', 1)");
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (213, 2005, 'NS-313-313', 1)");
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (4321, 2008, 'NS-321-897', 2)");
            Sql("INSERT INTO vehicles(TaxiNumber, VehicleYear, RegistrationNumber, VehicleType) VALUES (4324, 2019, 'NS-789-423', 2)");

            Sql("INSERT INTO Users(Username, Name, Password, Surname, JMBG, Email, PhoneNumber, Gender, Role, " +
               "Discriminator, Location_Id, Vehicle_Id, Vehicle_TaxiNumber) VALUES" +
               " ('john', 'John', 'johnny', 'Doe', '3108994123654', 'john@gmail.com', '+38143435211'," +
               "0, 2, 'Driver', 10, 8, '3214' )");
            Sql("INSERT INTO Users(Username, Name, Password, Surname, JMBG, Email, PhoneNumber, Gender, Role, " +
              "Discriminator, Location_Id, Vehicle_Id, Vehicle_TaxiNumber) VALUES" +
              " ('missy', 'Mis', 'tea', 'Tea', '2904885238923', 'mis@gmail.com', '+381425656678'," +
              "1, 2, 'Driver', 14, 6, '4893' )");
            Sql("INSERT INTO Users(Username, Name, Password, Surname, JMBG, Email, PhoneNumber, Gender, Role, " +
              "Discriminator, Location_Id, Vehicle_Id, Vehicle_TaxiNumber) VALUES" +
              " ('bruce', 'Bruce', 'bro', 'Lee', '1409889457832', 'brus@gmail.com', '+381309324789'," +
              "0, 2, 'Driver', 9, 10, '4321' )");
            Sql("INSERT INTO Users(Username, Name, Password, Surname, JMBG, Email, PhoneNumber, Gender, Role, " +
              "Discriminator, Location_Id, Vehicle_Id, Vehicle_TaxiNumber) VALUES" +
              " ('sam', 'Sam', 's', 'Smith', '1801991838001', 'sam@gmail.com', '+38134546'," +
              "0, 2, 'Driver', 5, 7, '445' )");
            Sql("INSERT INTO Users(Username, Name, Password, Surname, JMBG, Email, PhoneNumber, Gender, Role, " +
              "Discriminator, Location_Id, Vehicle_Id, Vehicle_TaxiNumber) VALUES" +
              " ('scarlet', 'Scarlet', 'scary', 'Witch', '1103998384813', 'scarlet@gmail.com', '+3814256784'," +
              "1, 2, 'Driver', 13, 11, '4324' )");
        }
        
        public override void Down()
        {
        }
    }
}
