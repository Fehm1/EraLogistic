using AutoMapper;
using Business.Abstract;
using Core.Extentions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutUsDto;
using Entities.DTOs.SettingDto;
using Entities.DTOs.SliderDto;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete
{
    public class SettingManager : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SettingManager(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }
        public async Task<IDataResult<SettingDto>> Get(int settingId)
        {
            var setting = await _unitOfWork.Settings.GetAsync(x => x.Id == settingId);

            if (setting != null)
            {
                return new DataResult<SettingDto>(ResultStatus.Success, new SettingDto
                {
                    Setting = setting,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SettingDto>(ResultStatus.Error, "Parametr tapılmadı!", new SettingDto
            {
                Setting = null,
                ResultStatus = ResultStatus.Error,
                Message = "Parametr tapılmadı!"
            });
        }

        public async Task<IDataResult<SettingUpdateDto>> GetUpdateDto(int settingId)
        {
            var result = await _unitOfWork.Settings.AnyAsync(c => c.Id == settingId);
            if (result)
            {
                var setting = await _unitOfWork.Settings.GetAsync(c => c.Id == settingId);
                var settingUpdateDto = _mapper.Map<SettingUpdateDto>(setting);
                return new DataResult<SettingUpdateDto>(ResultStatus.Success, settingUpdateDto);
            }
            else
            {
                return new DataResult<SettingUpdateDto>(ResultStatus.Error, "Nəticə tapılmadı!", null);
            }
        }

        public async Task<IDataResult<SettingDto>> Update(SettingUpdateDto settingUpdateDto)
        {
            var setting = await _unitOfWork.Settings.GetAsync(x => x.Id == settingUpdateDto.Id);

            if (setting != null)
            {

                if (settingUpdateDto.HeaderLogoFile != null)
                {
                    if (!settingUpdateDto.HeaderLogoFile.IsImageContent())
                    {
                        return new DataResult<SettingDto>(ResultStatus.Error, "Şəkil formatı daxil edin!", new SettingDto
                        {
                            Setting = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkil formatı daxil edin!"
                        });
                    }

                    if (!settingUpdateDto.HeaderLogoFile.IsValidImageLength())
                    {
                        return new DataResult<SettingDto>(ResultStatus.Error, "Şəkilin həcmi böyükdür!", new SettingDto
                        {
                            Setting = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkilin həcmi böyükdür!"
                        });
                    }

                    string newImage = settingUpdateDto.HeaderLogoFile.SaveImage(_env.WebRootPath, "uploads/Setting");
                    setting.HeaderLogo.DeleteImage(_env.WebRootPath, "uploads/Setting");

                    setting.HeaderLogo = newImage;
                }

                if (settingUpdateDto.FooterLogoFile != null)
                {
                    if (!settingUpdateDto.FooterLogoFile.IsImageContent())
                    {
                        return new DataResult<SettingDto>(ResultStatus.Error, "Şəkil formatı daxil edin!", new SettingDto
                        {
                            Setting = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkil formatı daxil edin!"
                        });
                    }

                    if (!settingUpdateDto.FooterLogoFile.IsValidImageLength())
                    {
                        return new DataResult<SettingDto>(ResultStatus.Error, "Şəkilin həcmi böyükdür!", new SettingDto
                        {
                            Setting = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkilin həcmi böyükdür!"
                        });
                    }

                    string newImage = settingUpdateDto.FooterLogoFile.SaveImage(_env.WebRootPath, "uploads/Setting");
                    setting.FooterLogo.DeleteImage(_env.WebRootPath, "uploads/Setting");

                    setting.FooterLogo = newImage;
                }

                setting.AboutUsYellowTitle = settingUpdateDto.AboutUsYellowTitle;
                setting.AboutUsWhiteTitle = settingUpdateDto.AboutUsWhiteTitle;
                setting.AboutUsDescription = settingUpdateDto.AboutUsDescription;
                setting.VideoYellowTitle = settingUpdateDto.VideoYellowTitle;
                setting.VideoWhiteTitle = settingUpdateDto.VideoWhiteTitle;
                setting.VideoLittleDescription = settingUpdateDto.VideoLittleDescription;
                setting.VideoDescription = settingUpdateDto.VideoDescription;
                setting.VideoLink = settingUpdateDto.VideoLink;
                setting.OurServiceYellowTitle = settingUpdateDto.OurServiceYellowTitle;
                setting.OurServiceWhiteTitle = settingUpdateDto.OurServiceWhiteTitle;
                setting.OurServiceDescription = settingUpdateDto.OurServiceDescription;
                setting.OurPackageYellowTitle = settingUpdateDto.OurPackageYellowTitle;
                setting.OurPackageWhiteTitle = settingUpdateDto.OurPackageWhiteTitle;
                setting.OurPackageDescription = settingUpdateDto.OurPackageDescription;
                setting.Email = settingUpdateDto.Email;
                setting.Phone = settingUpdateDto.Phone;
                setting.Address = settingUpdateDto.Address;
                setting.Instagram = settingUpdateDto.Instagram;
                setting.Facebook = settingUpdateDto.Facebook;
                setting.Twitter = settingUpdateDto.Twitter;
                setting.Youtube = settingUpdateDto.Youtube;
                setting.LinkedIn = settingUpdateDto.LinkedIn;
                setting.WhatsApp = settingUpdateDto.WhatsApp;
                setting.GoogleMapsLocation = settingUpdateDto.GoogleMapsLocation;
                setting.ModifiedDate = DateTime.Now;

                var updatedSetting = await _unitOfWork.Settings.UpdateAsync(setting);
                await _unitOfWork.SaveAsync();

                return new DataResult<SettingDto>(ResultStatus.Success, "Parametrlər uğurla yeniləndi!", new SettingDto
                {
                    Setting = updatedSetting,
                    ResultStatus= ResultStatus.Success,
                    Message = "Parametrlər uğurla yeniləndi!"
                });
            }

            return new DataResult<SettingDto>(ResultStatus.Error, "Parametr tapılmadı!", new SettingDto
            {
                Setting = null,
                ResultStatus = ResultStatus.Error,
                Message = "Parametr tapılmadı!"
            });
        }
    }
}
