namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsersAgain : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE users SET Vehicle_Id = 2, Vehicle_TaxiNumber = '45' WHERE Id = 4");
        }
    
        
        public override void Down()
        {
        }
    }
}
