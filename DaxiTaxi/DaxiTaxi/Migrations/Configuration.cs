namespace DaxiTaxi.Migrations
{
    using DaxiTaxi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DaxiTaxi.Context.TaxiAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DaxiTaxi.Context.TaxiAppContext context)
        {
            var admin = new Admin()
            {
                Id = 1,
                Username = "pera",
                Name = "pera",
                Password = "pera123",
                JMBG = "1234567891234",
                PhoneNumber = "+381643234345",
                Gender = EGender.MALE,
                Surname = "peric",
                Email = "pera@gmail.com",
                Role = ERole.ADMIN
            };

            var customer = new Customer()
            {
                Id = 3,
                Username = "sanja",
                Name = "sanja",
                Password = "sanja123",
                JMBG = "9293945583123",
                PhoneNumber = "+381620023456",
                Gender = EGender.FEMALE,
                Surname = "savic",
                Email = "sanja@gmail.com",
                Role = ERole.CUSTOMER
            };

            var address1 = new Address()
            {
                Id = 1,
                City = "Novi Sad",
                CallNumber = 21000,
                Street = "Despota Stefana",
                StreetNumber = 7
            };

            var address2 = new Address()
            {
                Id = 2,
                City = "Novi Sad",
                CallNumber = 21000,
                Street = "Pap Pavla",
                StreetNumber = 18
            };

            var address3 = new Address()
            {
                Id = 3,
                City = "Novi Sad",
                CallNumber = 21000,
                Street = "Bulevar Oslobodjenja",
                StreetNumber = 88
            };

            Address addressLocation1 = context.Addresses.Single(x => x.Id == 1);
            Address addressLocation2 = context.Addresses.Single(x => x.Id == 2);
            Address addressLocation3 = context.Addresses.Single(x => x.Id == 3);

            var location1 = new Location()
            {
                Id = 1,
                XCoordinate = 45.236300,
                YCoordinate = 19.838230,
                Address = addressLocation1
            };

            var location2 = new Location()
            {
                Id = 2,
                XCoordinate = 45.264500,
                YCoordinate = 19.813150,
                Address = addressLocation2
            };

            var location3 = new Location()
            {
                Id = 3,
                XCoordinate = 45.248730,
                YCoordinate = 19.838150,
                Address = addressLocation3
            };

            Location driverLocation = context.Locations.Single(x => x.Id == 1);
            Location driverLocation1 = context.Locations.Single(x => x.Id == 2);

            var driver = new Driver()
            {
                Id = 2,
                Username = "maki",
                Name = "Marko",
                Surname = "Markovic",
                Password = "batman",
                JMBG = "2345921394578",
                PhoneNumber = "+381602394291",
                Gender = EGender.MALE,
                Role = ERole.DRIVER,
                Email = "maki@gmail.com",
                Location = driverLocation
            };

            var driver1 = new Driver()
            {
                Id = 4,
                Username = "alex",
                Name = "Aleksandar",
                Surname = "Aleksic",
                Password = "trotinet",
                JMBG = "9394592345781",
                PhoneNumber = "+381623457681",
                Gender = EGender.MALE,
                Role = ERole.DRIVER,
                Email = "alex@gmail.com",
                Location = driverLocation1
            };

            Driver vehicleDriver1 = (Driver)context.Users.Single(x => x.Id == 2);
            Driver vehicleDriver2 = (Driver)context.Users.Single(x => x.Id == 4);

            var vehicle1 = new Vehicle()
            {
                Id = 1,
                Driver = vehicleDriver1,
                RegistrationNumber = "NS-235-234",
                TaxiNumber = 23,
                VehicleType = EVehicleType.PassengerVehicle,
                VehicleYear = 2014
            };

            var vehicle2 = new Vehicle()
            {
                Id = 2,
                Driver = vehicleDriver2,
                RegistrationNumber = "LO-134-234",
                TaxiNumber = 45,
                VehicleType = EVehicleType.Van,
                VehicleYear = 2016
            };

            Customer commentCustomer = (Customer)context.Users.Single(x => x.Id == 3);

            var comment = new Comment()
            {
                Id = 1,
                Description = "Excelent service",
                PublishDate = DateTime.Parse("2019-01-23 23:00:00"),
                Rate = 5,
                UserThatLeftComment = commentCustomer
            };


            context.Addresses.AddOrUpdate(a => a.Id, address1, address2, address3);

            context.Locations.AddOrUpdate(l => l.Id, location1, location2, location3);

            context.Users.AddOrUpdate(u => u.Id, admin, customer, driver, driver1);

            context.Vehicles.AddOrUpdate(v => v.Id, vehicle1, vehicle2);

            context.Comments.AddOrUpdate(c => c.Id, comment);
        }
    }
}
