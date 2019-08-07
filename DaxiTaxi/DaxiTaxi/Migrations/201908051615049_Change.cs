namespace DaxiTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "Rides", name: "CurrentLocation_Id", newName: "CustomerLocation_Id");
            //RenameIndex(table: "Rides", name: "IX_CurrentLocation_Id", newName: "IX_CustomerLocation_Id");
        }
        
        public override void Down()
        {
            //RenameIndex(table: "Rides", name: "IX_CustomerLocation_Id", newName: "IX_CurrentLocation_Id");
            //RenameColumn(table: "Rides", name: "CustomerLocation_Id", newName: "CurrentLocation_Id");
        }
    }
}
