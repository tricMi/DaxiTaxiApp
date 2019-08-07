using AutoMapper;
using DaxiTaxi.DTOs;
using DaxiTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.App_Start
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<Admin, AdminDTO>();
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Driver, DriverDTO>();
            Mapper.CreateMap<Ride, RideDTO>();
            Mapper.CreateMap<Vehicle, VehicleDTO>();
            Mapper.CreateMap<Address, AddressDTO>();
            Mapper.CreateMap<Location, LocationDTO>();
            Mapper.CreateMap<EGender, EGenderDTO>();
            Mapper.CreateMap<ERideState, ERideStateDTO>();
            Mapper.CreateMap<EVehicleType, EVehicleTypeDTO>();
            Mapper.CreateMap<ERole, ERoleDTO>();
            Mapper.CreateMap<Comment, CommentDTO>();
        }
    }
}