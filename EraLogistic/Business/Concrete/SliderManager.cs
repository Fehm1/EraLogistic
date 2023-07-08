using AutoMapper;
using Business.Abstract;
using Core.Extentions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.SliderDto;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SliderManager(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IDataResult<SliderDto>> Add(SliderPostDto sliderPostDto)
        {
            if (sliderPostDto != null)
            {
                var slider = _mapper.Map<Slider>(sliderPostDto);

                if (sliderPostDto.Image != null)
                {
                    if (!sliderPostDto.Image.IsImageContent())
                    {
                        return new DataResult<SliderDto>(ResultStatus.Error, "Şəkil formatı daxil edin!", new SliderDto
                        {
                            Slider = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkil formatı daxil edin!"
                        });
                    }

                    if (!sliderPostDto.Image.IsValidImageLength())
                    {
                        return new DataResult<SliderDto>(ResultStatus.Error, "Şəkilin həcmi böyükdür!", new SliderDto
                        {
                            Slider = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkilin həcmi böyükdür!"
                        });
                    }

                    string newImage = sliderPostDto.Image.SaveImage(_env.WebRootPath, "uploads/Sliders");
                }
                else
                {
                    return new DataResult<SliderDto>(ResultStatus.Error, "Şəkil daxil edin!", new SliderDto
                    {
                        Slider = null,
                        ResultStatus = ResultStatus.Error,
                        Message = "Şəkil daxil edin!"
                    });
                }


                var addedSlider = await _unitOfWork.Sliders.AddAsync(slider);
                await _unitOfWork.SaveAsync();
                SliderDto sliderGetDto = _mapper.Map<SliderDto>(slider);

                return new DataResult<SliderDto>(ResultStatus.Success, "Slayder uğurla əlavə olundu!", new SliderDto
                {
                    Slider = addedSlider,
                    ResultStatus = ResultStatus.Success,
                    Message = "Slayder uğurla əlavə olundu!"
                });
            }

            return new DataResult<SliderDto>(ResultStatus.Error, "Məlumatlar əlavə olunmadı!", new SliderDto
            {
                Slider = null,
                ResultStatus = ResultStatus.Error,
                Message = "Məlumatlar əlavə olunmadı!"
            });
        }

        public async Task<IDataResult<SliderDto>> Delete(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                slider.IsDeleted = true;
                var deletedSlider = await _unitOfWork.Sliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();

                return new DataResult<SliderDto>(ResultStatus.Success, "Slayder uğurla silindi!", new SliderDto
                {
                    Slider = deletedSlider,
                    ResultStatus = ResultStatus.Success,
                    Message = "Slayder uğurla silindi!"
                });
            }

            return new DataResult<SliderDto>(ResultStatus.Error, "Slayder tapılmadı!", new SliderDto
            {
                Slider = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayder tapılmadı!"
            });
        }

        public async Task<IDataResult<SliderDto>> Get(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                return new DataResult<SliderDto>(ResultStatus.Success, new SliderDto
                {
                    Slider = slider,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SliderDto>(ResultStatus.Error, "Slayder tapılmadı!", new SliderDto
            {
                Slider = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayder tapılmadı!"
            });
        }

        public async Task<IDataResult<SliderListDto>> GetAll()
        {
            var sliders = await _unitOfWork.Sliders.GetAllAsync();
            if (sliders.Count >= 0)
            {
                return new DataResult<SliderListDto>(ResultStatus.Success, new SliderListDto
                {
                    Sliders = sliders,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SliderListDto>(ResultStatus.Error, "Slayderlər tapılmadı!", new SliderListDto
            {
                Sliders = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayderlər tapılmadı!"
            });
        }

        public async Task<IDataResult<SliderListDto>> GetAllByDeleted()
        {
            var sliders = await _unitOfWork.Sliders.GetAllAsync(x => x.IsDeleted);
            if (sliders.Count >= 0)
            {
                return new DataResult<SliderListDto>(ResultStatus.Success, new SliderListDto
                {
                    Sliders = sliders,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SliderListDto>(ResultStatus.Error, "Slayderlər tapılmadı!", new SliderListDto
            {
                Sliders = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayderlər tapılmadı!"
            });
        }

        public async Task<IDataResult<SliderListDto>> GetAllByNonDeleted()
        {
            var sliders = await _unitOfWork.Sliders.GetAllAsync(x => !x.IsDeleted);
            if (sliders.Count >= 0)
            {
                return new DataResult<SliderListDto>(ResultStatus.Success, new SliderListDto
                {
                    Sliders = sliders,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SliderListDto>(ResultStatus.Error, "Slayderlər tapılmadı!", new SliderListDto
            {
                Sliders = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayderlər tapılmadı!"
            });
        }

        public async Task<IDataResult<SliderDto>> HardDelete(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                var deletedSlider = await _unitOfWork.Sliders.DeleteAsync(slider);
                await _unitOfWork.SaveAsync();

                return new DataResult<SliderDto>(ResultStatus.Success, "Slayder uğurla silindi!", new SliderDto
                {
                    Slider = deletedSlider,
                    ResultStatus = ResultStatus.Success,
                    Message = "Slayder uğurla silindi!"
                });
            }

            return new DataResult<SliderDto>(ResultStatus.Error, "Slayder tapılmadı!", new SliderDto
            {
                Slider = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayder tapılmadı!"
            });
        }

        public async Task<IDataResult<SliderDto>> Restore(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                slider.IsDeleted = false;
                var updatedSlider = await _unitOfWork.Sliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();

                return new DataResult<SliderDto>(ResultStatus.Success, "Slayder uğurla geri qaytarıldı!", new SliderDto
                {
                    Slider = updatedSlider,
                    ResultStatus = ResultStatus.Success,
                    Message = "Slayder uğurla geri qaytarıldı!"
                });
            }

            return new DataResult<SliderDto>(ResultStatus.Error, "Slayder tapılmadı!", new SliderDto
            {
                Slider = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayder tapılmadı!"
            });
        }

        public async Task<IDataResult<SliderDto>> Update(SliderUpdateDto sliderUpdateDto)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderUpdateDto.Id);

            if (slider != null)
            {
                if (sliderUpdateDto.Image != null)
                {
                    if (!sliderUpdateDto.Image.IsImageContent())
                    {
                        return new DataResult<SliderDto>(ResultStatus.Error, "Şəkil formatı daxil edin!", new SliderDto
                        {
                            Slider = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkil formatı daxil edin!"
                        });
                    }

                    if (!sliderUpdateDto.Image.IsValidImageLength())
                    {
                        return new DataResult<SliderDto>(ResultStatus.Error, "Şəkilin həcmi böyükdür!", new SliderDto
                        {
                            Slider = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkilin həcmi böyükdür!"
                        });
                    }

                    string newImage = sliderUpdateDto.Image.SaveImage(_env.WebRootPath, "uploads/Sliders");
                    slider.Image.DeleteImage(_env.WebRootPath, "uploads/Sliders");

                    slider.Image = newImage;
                }

                slider.Title = sliderUpdateDto.Title;
                slider.Description = sliderUpdateDto.Description;
                slider.RedirectUrl = sliderUpdateDto.RedirectUrl;
                slider.IsActive = sliderUpdateDto.IsActive;
                slider.ModifiedDate = DateTime.Now;

                var updatedSlider = await _unitOfWork.Sliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();

                return new DataResult<SliderDto>(ResultStatus.Success, "Slayder uğurla yeniləndi!", new SliderDto
                {
                    Slider = updatedSlider,
                    ResultStatus = ResultStatus.Success,
                    Message = "Slayder uğurla yeniləndi!"
                });
            }

            return new DataResult<SliderDto>(ResultStatus.Error, "Slayder tapılmadı!", new SliderDto
            {
                Slider = null,
                ResultStatus = ResultStatus.Error,
                Message = "Slayder tapılmadı!"
            });
        }
    }
}
