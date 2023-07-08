using AutoMapper;
using Business.Abstract;
using Core.Extentions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutUsDto;
using Microsoft.AspNetCore.Hosting;



namespace Business.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public AboutUsManager(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IDataResult<AboutUsDto>> Get(int AboutUsId)
        {
            var aboutUs = await _unitOfWork.AboutUs.GetAsync(x => x.Id == AboutUsId);

            if (aboutUs != null)
            {
                return new DataResult<AboutUsDto>(ResultStatus.Success, new AboutUsDto
                {
                    AboutUs = aboutUs,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutUsDto>(ResultStatus.Error, "Məlumat tapılmadı!", new AboutUsDto
            {
                AboutUs = null,
                ResultStatus = ResultStatus.Error,
                Message = "Məlumatlar tapılmadı!"
            });
        }

        public async Task<IDataResult<AboutUsDto>> Update(AboutUsUpdateDto aboutUsUpdateDto)
        {
            var aboutUs = await _unitOfWork.AboutUs.GetAsync(x => x.Id == aboutUsUpdateDto.Id);

            if (aboutUs != null)
            {
                if (aboutUsUpdateDto.Image != null)
                {
                    if (!aboutUsUpdateDto.Image.IsImageContent())
                    {
                        return new DataResult<AboutUsDto>(ResultStatus.Error, "Şəkil formatı daxil edin!", new AboutUsDto
                        {
                            AboutUs = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkil formatı daxil edin!"
                        });
                    }

                    if (!aboutUsUpdateDto.Image.IsValidImageLength())
                    {
                        return new DataResult<AboutUsDto>(ResultStatus.Error, "Şəkilin həcmi böyükdür!", new AboutUsDto
                        {
                            AboutUs = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkilin həcmi böyükdür!"
                        });
                    }

                    string newImage = aboutUsUpdateDto.Image.SaveImage(_env.WebRootPath, "uploads/AboutUs");
                    aboutUs.Image.DeleteImage(_env.WebRootPath, "uploads/AboutUs");

                    aboutUs.Image = newImage;
                }

                aboutUs.Title = aboutUsUpdateDto.Title;
                aboutUs.Description = aboutUsUpdateDto.Description;
                aboutUs.AdvantagesDescription = aboutUsUpdateDto.AdvantagesDescription;
                aboutUs.MissionDescription = aboutUsUpdateDto.MissionDescription;
                aboutUs.GuaranteedDescription = aboutUsUpdateDto.GuaranteedDescription;
                aboutUs.RedirectUrl = aboutUsUpdateDto.RedirectUrl;
                aboutUs.Feature1 = aboutUsUpdateDto.Feature1;
                aboutUs.Feature2 = aboutUsUpdateDto.Feature2;
                aboutUs.Feature3 = aboutUsUpdateDto.Feature3;
                aboutUs.Feature4 = aboutUsUpdateDto.Feature4;
                aboutUs.Feature5 = aboutUsUpdateDto.Feature5;
                aboutUs.Feature6 = aboutUsUpdateDto.Feature6;
                aboutUs.IsActive = aboutUsUpdateDto.IsActive;
                aboutUs.ModifiedDate = DateTime.Now;

                var updatedAboutUs = await _unitOfWork.AboutUs.UpdateAsync(aboutUs);
                await _unitOfWork.SaveAsync();

                return new DataResult<AboutUsDto>(ResultStatus.Success, "Məlumatlar uğurla yeniləndi!", new AboutUsDto
                {
                    AboutUs = updatedAboutUs,
                    ResultStatus = ResultStatus.Error,
                    Message = "Məlumatlar uğurla yeniləndi!"
                });
            }

            return new DataResult<AboutUsDto>(ResultStatus.Error, "Məlumatlar tapılmadı!", new AboutUsDto
            {
                AboutUs = null,
                ResultStatus = ResultStatus.Error,
                Message = "Məlumatlar tapılmadı!"
            });
        }
    }
}
