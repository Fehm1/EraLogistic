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

        public async Task<IResult> Add(SliderPostDto sliderPostDto)
        {
            if (sliderPostDto != null)
            {
                var slider = _mapper.Map<Slider>(sliderPostDto);

                if (sliderPostDto.Image != null)
                {
                    if (!sliderPostDto.Image.IsImageContent())
                    {
                        return new Result(ResultStatus.Error, "Şəkil formatı daxil edin!");
                    }

                    if (!sliderPostDto.Image.IsValidImageLength())
                    {
                        return new Result(ResultStatus.Error, "Şəkilin həcmi böyükdür!");
                    }

                    string newImage = sliderPostDto.Image.SaveImage(_env.WebRootPath, "uploads/Sliders");
                }
                else
                {
                    return new Result(ResultStatus.Error, "Şəkil daxil edin!");
                }


                await _unitOfWork.Sliders.AddAsync(slider);
                await _unitOfWork.SaveAsync();
                SliderGetDto sliderGetDto = _mapper.Map<SliderGetDto>(slider);

                return new Result(ResultStatus.Success, "Slayder uğurla əlavə olundu!");
            }

            return new Result(ResultStatus.Error, "Məlumatlar əlavə olunmadı!");
        }

        public async Task<IResult> Delete(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                slider.IsDeleted = true;
                await _unitOfWork.Sliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Slayder uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Slayder tapılmadı!");
        }

        public async Task<IDataResult<Slider>> Get(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                return new DataResult<Slider>(ResultStatus.Success, slider);
            }
            return new DataResult<Slider>(ResultStatus.Error, "Slayder tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Slider>>> GetAll()
        {
            var sliders = await _unitOfWork.Sliders.GetAllAsync();
            if (sliders.Count >= 0)
            {
                return new DataResult<IList<Slider>>(ResultStatus.Success, sliders);
            }
            return new DataResult<IList<Slider>>(ResultStatus.Error, "Slayderlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Slider>>> GetAllByDeleted()
        {
            var sliders = await _unitOfWork.Sliders.GetAllAsync(x => x.IsDeleted);
            if (sliders.Count >= 0)
            {
                return new DataResult<IList<Slider>>(ResultStatus.Success, sliders);
            }
            return new DataResult<IList<Slider>>(ResultStatus.Error, "Slayderlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Slider>>> GetAllByNonDeleted()
        {
            var sliders = await _unitOfWork.Sliders.GetAllAsync(x => !x.IsDeleted);
            if (sliders.Count >= 0)
            {
                return new DataResult<IList<Slider>>(ResultStatus.Success, sliders);
            }
            return new DataResult<IList<Slider>>(ResultStatus.Error, "Slayderlər tapılmadı!", null);
        }

        public async Task<IResult> HardDelete(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                await _unitOfWork.Sliders.DeleteAsync(slider);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Slayder uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Slayder tapılmadı!");
        }

        public async Task<IResult> Restore(int sliderId)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderId);

            if (slider != null)
            {
                slider.IsDeleted = false;
                await _unitOfWork.Sliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Slayder uğurla geri qaytarıldı!");
            }

            return new Result(ResultStatus.Error, "Slayder tapılmadı!");
        }

        public async Task<IResult> Update(SliderUpdateDto sliderUpdateDto)
        {
            var slider = await _unitOfWork.Sliders.GetAsync(x => x.Id == sliderUpdateDto.Id);

            if (slider != null)
            {
                if (sliderUpdateDto.Image != null)
                {
                    if (!sliderUpdateDto.Image.IsImageContent())
                    {
                        return new Result(ResultStatus.Error, "Şəkil formatı daxil edin!");
                    }

                    if (!sliderUpdateDto.Image.IsValidImageLength())
                    {
                        return new Result(ResultStatus.Error, "Şəkilin həcmi böyükdür!");
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

                await _unitOfWork.Sliders.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Slayder uğurla yeniləndi!");
            }

            return new Result(ResultStatus.Error, "Slayder tapılmadı!");
        }
    }
}
