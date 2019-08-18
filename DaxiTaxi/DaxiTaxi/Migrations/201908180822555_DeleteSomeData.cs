namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSomeData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Rides SET Comment_Id = NULL WHERE Id = 17");
            Sql("DELETE FROM Comments WHERE Id = 7");
            
        }
        
        public override void Down()
        {
        }
    }
}
