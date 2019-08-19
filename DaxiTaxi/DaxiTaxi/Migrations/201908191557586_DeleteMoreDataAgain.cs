namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMoreDataAgain : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM addresses WHERE Id = 23");
            Sql("DELETE FROM locations WHERE Id = 23");
            Sql("DELETE FROM rides WHERE Id = 19");

        }
        
        public override void Down()
        {
        }
    }
}
