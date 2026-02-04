
using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using System.Xml.Serialization;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantProfile:Profile
    {
        public RestaurantProfile()
        {
            CreateMap<RestaurantDto, Restaurant>().ForMember(d => d.Address, opt => opt.MapFrom(scr => new Address
            {
                City = scr.City,
                Postal = scr.Postal,
                Street = scr.Street
            }));

            CreateMap<CreateRestaurantCommand, Restaurant>().ForMember(d => d.Address, opt => opt.MapFrom(scr => new Address
            {
                City = scr.City,
                Postal = scr.Postal,
                Street = scr.Street
            }));


            CreateMap<Restaurant, RestaurantDto>().ForMember(d => d.City, opt => opt.MapFrom(scr => scr.Address == null ? null : scr.Address.City))
            .ForMember(d => d.Postal, opt => opt.MapFrom(scr => scr.Address == null ? null : scr.Address.Postal))
            .ForMember(d => d.Street, opt => opt.MapFrom(scr => scr.Address == null ? null : scr.Address.Street))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

            CreateMap<Restaurant, CreateRestaurantCommand>().ForMember(d => d.City, opt => opt.MapFrom(scr => scr.Address == null ? null : scr.Address.City))
            .ForMember(d => d.Postal, opt => opt.MapFrom(scr => scr.Address == null ? null : scr.Address.Postal))
            .ForMember(d => d.Street, opt => opt.MapFrom(scr => scr.Address == null ? null : scr.Address.Street))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
        }
    }
}
