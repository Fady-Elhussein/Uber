using AutoMapper;
using Uber.DTOs.PaymentDto;
using Uber.DTOs.RatingDto;
using Uber.DTOs.RideDto;
using Uber.DTOs.UserDto;
using Uber.DTOs.VehicleDto;
using Uber.Model;

namespace Uber.AutoMapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Ride, RideDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();

            CreateMap<CreateVehicleDto, Vehicle>().ReverseMap();
            CreateMap<CreateRideDto, Ride>().ReverseMap();
            CreateMap<CreatePaymentDto, Payment>().ReverseMap();
            CreateMap<CreateRatingDto, Rating>().ReverseMap();
        }
    }
}
