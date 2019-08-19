namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAgainSomeData : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM addresses WHERE Id = 25");
            Sql("DELETE FROM addresses WHERE Id = 26");
            Sql("DELETE FROM locations WHERE Id = 25");
            Sql("DELETE FROM locations WHERE Id = 26");
            Sql("DELETE FROM rides WHERE Id = 21");
            Sql("DELETE FROM rides WHERE Id = 22");
        }
        
        public override void Down()
        {
        }
    }
}
