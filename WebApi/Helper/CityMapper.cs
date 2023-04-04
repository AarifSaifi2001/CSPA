using System.Linq;
using AutoMapper;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Helper
{
    public class CityMapper : Profile
    {
        
        public CityMapper()
        {
            CreateMap<Cities, CityModel>().ReverseMap();
            CreateMap<Car, CarModel>()
            .ForMember(d => d.location, opt => opt.MapFrom(src => src.City.name))
            .ForMember(d => d.fueltype, opt => opt.MapFrom(src => src.FuelType.fuel))
            .ForMember(d => d.Photo, opt => opt.MapFrom(src => src.Photos
                        .FirstOrDefault(p => p.isPrimary).imageUrl)); 

            CreateMap<Car, CarDetailModel>()
            .ForMember(d => d.location, opt => opt.MapFrom(src => src.City.name))
            .ForMember(d => d.fueltype, opt => opt.MapFrom(src => src.FuelType.fuel))
            .ForMember(d => d.btype, opt => opt.MapFrom(src => src.BodyType.body))
            .ForMember(d => d.PostedBy, opt => opt.MapFrom(src => src.User.id));

            CreateMap<FuelType, FuelTypeModel>().ReverseMap();
            CreateMap<BodyType, BodyTypeModel>().ReverseMap();
            CreateMap<Car, CarSaveModel>().ReverseMap();
            CreateMap<Photos, PhotosModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserModel2>().ReverseMap();
            CreateMap<User, UserPasswordUpdateModel>().ReverseMap();
        }
    }
}