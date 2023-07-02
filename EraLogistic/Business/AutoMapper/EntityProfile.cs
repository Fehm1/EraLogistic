using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AboutUsDto;
using Entities.DTOs.ContactDto;
using Entities.DTOs.PackageDto;
using Entities.DTOs.ProfessionDto;
using Entities.DTOs.ServiceDto;
using Entities.DTOs.SettingDto;
using Entities.DTOs.SliderDto;
using Entities.DTOs.TeamDto;

namespace Business.AutoMapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<AboutUs, AboutUsDto>();
            CreateMap<AboutUsPostDto, AboutUs>();

            CreateMap<Contact, ContactDto>();
            CreateMap<ContactPostDto, Contact>();

            CreateMap<Package, PackageDto>();
            CreateMap<PackagePostDto, Package>();

            CreateMap<Profession, ProfessionDto>();
            CreateMap<ProfessionPostDto, Profession>();

            CreateMap<Service, ServiceDto>();
            CreateMap<ServicePostDto, Service>();

            CreateMap<Setting, SettingDto>();
            CreateMap<SettingPostDto, Setting>();

            CreateMap<Slider, SliderDto>();
            CreateMap<SliderPostDto, Slider>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamPostDto, Team>();
        }
    }
}
