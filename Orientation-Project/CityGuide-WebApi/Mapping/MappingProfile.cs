using AutoMapper;
using CityGuide_WebApi.Models;
using CityGuide_WebApi.View_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddTouristsEntryViewModel, BaseTable>().ReverseMap();
            CreateMap<AddTouristsEntryViewModel, TouristsAmenities>().ReverseMap().
                ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.BaseTable.Address)).
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BaseTable.Name)).
                ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.BaseTable.Latitude)).
                ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.BaseTable.Longitude)).
                ForMember(dest => dest.NearestMetro, opt => opt.MapFrom(src => src.BaseTable.NearestMetro)).
                ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.BaseTable.OpeningTime)).
                ForMember(dest => dest.Information, opt => opt.MapFrom(src => src.BaseTable.Information)).
                ForMember(dest => dest.ClosingTime, opt => opt.MapFrom(src => src.BaseTable.ClosingTime)).
                ForMember(dest => dest.Altitude, opt => opt.MapFrom(src => src.BaseTable.Altitude));

    ;

            CreateMap<AddAccommodationAmenitiesViewModel, BaseTable>().ReverseMap();
            CreateMap<AddAccommodationAmenitiesViewModel, AccommodationAmenities>().ReverseMap().
            ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.BaseTable.Address)).
            ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BaseTable.Name)).
            ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.BaseTable.Latitude)).
            ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.BaseTable.Longitude)).
            ForMember(dest => dest.NearestMetro, opt => opt.MapFrom(src => src.BaseTable.NearestMetro)).
            ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.BaseTable.OpeningTime)).
            ForMember(dest => dest.Information, opt => opt.MapFrom(src => src.BaseTable.Information)).
            ForMember(dest => dest.ClosingTime, opt => opt.MapFrom(src => src.BaseTable.ClosingTime)).
            ForMember(dest => dest.Altitude, opt => opt.MapFrom(src => src.BaseTable.Altitude));

            CreateMap<AddActivitiesAmenitiesViewModel, BaseTable>().ReverseMap();
            CreateMap<AddActivitiesAmenitiesViewModel, ActivitiesAmenities>().ReverseMap().
            ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.BaseTable.Address)).
            ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BaseTable.Name)).
            ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.BaseTable.Latitude)).
            ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.BaseTable.Longitude)).
            ForMember(dest => dest.NearestMetro, opt => opt.MapFrom(src => src.BaseTable.NearestMetro)).
            ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.BaseTable.OpeningTime)).
            ForMember(dest => dest.Information, opt => opt.MapFrom(src => src.BaseTable.Information)).
            ForMember(dest => dest.ClosingTime, opt => opt.MapFrom(src => src.BaseTable.ClosingTime)).
            ForMember(dest => dest.Altitude, opt => opt.MapFrom(src => src.BaseTable.Altitude));


            CreateMap<AddFoodAmenitiesViewModel, BaseTable>().ReverseMap();
            CreateMap<AddFoodAmenitiesViewModel, FoodAmenities>().ReverseMap().
            ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.BaseTable.Address)).
            ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BaseTable.Name)).
            ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.BaseTable.Latitude)).
            ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.BaseTable.Longitude)).
            ForMember(dest => dest.NearestMetro, opt => opt.MapFrom(src => src.BaseTable.NearestMetro)).
            ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.BaseTable.OpeningTime)).
            ForMember(dest => dest.Information, opt => opt.MapFrom(src => src.BaseTable.Information)).
            ForMember(dest => dest.ClosingTime, opt => opt.MapFrom(src => src.BaseTable.ClosingTime)).
            ForMember(dest => dest.Altitude, opt => opt.MapFrom(src => src.BaseTable.Altitude));

            CreateMap<BlogViewModel, BlogModel>().ReverseMap();
            
            CreateMap<EditBlogViewModel, BlogModel>().ReverseMap();

            CreateMap<UserBlogViewModel, UserBlog>().ReverseMap();

        }
    }
}
