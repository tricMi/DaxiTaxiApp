namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreDrivers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users(Username, Name, Password, Surname, JMBG, Email, PhoneNumber, Gender, Role, " +
                "Discriminator, Location_Id, Vehicle_Id, Vehicle_TaxiNumber) VALUES" +
                " ('daki', 'Dax', 'daxi', 'Valley', '1309978234829', 'dax@gmail.com', '+3813452213'," +
                "0, 2, 'Driver', 5, 5, '2' )");
        }
        
        public override void Down()
        {
        }
    }
}
