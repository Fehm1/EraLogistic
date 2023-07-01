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
            CreateMap<AboutUs, AboutUsGetDto>();
            CreateMap<AboutUsPostDto, AboutUs>();

            CreateMap<Contact, ContactGetDto>();
            CreateMap<ContactPostDto, Contact>();

            CreateMap<Package, PackageGetDto>();
            CreateMap<PackagePostDto, Package>();

            CreateMap<Profession, ProfessionGetDto>();
            CreateMap<ProfessionPostDto, Profession>();

            CreateMap<Service, ServiceGetDto>();
            CreateMap<ServicePostDto, Service>();

            CreateMap<Setting, SettingGetDto>();
            CreateMap<SettingPostDto, Setting>();

            CreateMap<Slider, SliderGetDto>();
            CreateMap<SliderPostDto, Slider>();

            CreateMap<Team, TeamGetDto>();
            CreateMap<TeamPostDto, Team>();
        }
    }
}
