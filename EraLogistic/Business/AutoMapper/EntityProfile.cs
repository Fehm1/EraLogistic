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
            CreateMap<AboutUsUpdateDto, AboutUs>();
            CreateMap<AboutUs, AboutUsUpdateDto>();

            CreateMap<Contact, ContactDto>();
            CreateMap<ContactPostDto, Contact>();

            CreateMap<Package, PackageDto>();
            CreateMap<PackagePostDto, Package>();
            CreateMap<PackageUpdateDto, Package>();
            CreateMap<Package, PackageUpdateDto>();

            CreateMap<Profession, ProfessionDto>();
            CreateMap<ProfessionPostDto, Profession>();
            CreateMap<ProfessionUpdateDto, Profession>();
            CreateMap<Profession, ProfessionUpdateDto>();

            CreateMap<Service, ServiceDto>();
            CreateMap<ServicePostDto, Service>();
            CreateMap<ServiceUpdateDto, Service>();
            CreateMap<Service, ServiceUpdateDto>();

            CreateMap<Setting, SettingDto>();
            CreateMap<SettingUpdateDto, Setting>();
            CreateMap<Setting, SettingUpdateDto>();

            CreateMap<Slider, SliderDto>();
            CreateMap<SliderPostDto, Slider>();
            CreateMap<SliderUpdateDto, Slider>();
            CreateMap<Slider, SliderUpdateDto>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamPostDto, Team>();
            CreateMap<TeamUpdateDto, Team>();
            CreateMap<Team, TeamUpdateDto>();
        }
    }
}
