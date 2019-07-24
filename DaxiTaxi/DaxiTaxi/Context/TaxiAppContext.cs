using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using System.Data.Entity;
using DaxiTaxi.Models;

namespace DaxiTaxi.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class TaxiAppContext : DbContext
    {
        //Connection string reference name
        public TaxiAppContext() : base("TaxiAppCon") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Ride> Rides { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Location> Locations { get; set; }

    }
}