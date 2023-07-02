using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProfessionDto;

namespace Business.Concrete
{
    public class ProfessionManager : IProfessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfessionManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ProfessionPostDto professionPostDto)
        {
            if (professionPostDto != null)
            {
                var profession = _mapper.Map<Profession>(professionPostDto);

                await _unitOfWork.Professions.AddAsync(profession);
                await _unitOfWork.SaveAsync();

                ProfessionDto professionGetDto = _mapper.Map<ProfessionDto>(profession);

                return new Result(ResultStatus.Success, $"{professionPostDto.ProfessionName} uğurla əlavə olundu!");
            }

            return new Result(ResultStatus.Error, "Məlumatlar əlavə olunmadı!");
        }

        public async Task<IResult> Delete(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id ==  professionId);

            if (profession != null)
            {
                profession.IsDeleted = true;
                await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Vəzifə uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Vəzifə tapılmadı!");
        }

        public async Task<IDataResult<ProfessionDto>> Get(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId, x => x.Teams);

            if (profession != null)
            {
                return new DataResult<ProfessionDto>(ResultStatus.Success, new ProfessionDto
                {
                    Profession = profession,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProfessionDto>(ResultStatus.Error, "Vəzifə tapılmadı!",null);
        }

        public async Task<IDataResult<ProfessionListDto>> GetAll()
        {
            var professions = await _unitOfWork.Professions.GetAllAsync(null, x => x.Teams);
            if (professions.Count >= 0)
            {
                return new DataResult<ProfessionListDto>(ResultStatus.Success, new ProfessionListDto
                {
                    Professions = professions,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProfessionListDto>(ResultStatus.Error, "Vəzifələr tapılmadı!", null);
        }

        public async Task<IDataResult<ProfessionListDto>> GetAllByDeleted()
        {
            var professions = await _unitOfWork.Professions.GetAllAsync(x => x.IsDeleted, x => x.Teams);
            if (professions.Count >= 0)
            {
                return new DataResult<ProfessionListDto>(ResultStatus.Success, new ProfessionListDto
                {
                    Professions = professions,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProfessionListDto>(ResultStatus.Error, "Vəzifələr tapılmadı!", null);
        }

        public async Task<IDataResult<ProfessionListDto>> GetAllByNonDeleted()
        {
            var professions = await _unitOfWork.Professions.GetAllAsync(x => !x.IsDeleted, x => x.Teams);
            if (professions.Count >= 0)
            {
                return new DataResult<ProfessionListDto>(ResultStatus.Success, new ProfessionListDto { 
                    Professions = professions, 
                    ResultStatus = ResultStatus.Success 
                });
            }
            return new DataResult<ProfessionListDto>(ResultStatus.Error, "Vəzifələr tapılmadı!", null);
        }

        public async Task<IResult> HardDelete(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId);

            if (profession != null)
            {
                await _unitOfWork.Professions.DeleteAsync(profession);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Vəzifə uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Vəzifə tapılmadı!");
        }

        public async Task<IResult> Restore(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId);

            if (profession != null)
            {
                profession.IsDeleted = false;
                await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Vəzifə uğurla geri qaytarıldı!");
            }

            return new Result(ResultStatus.Error, "Vəzifə tapılmadı!");
        }

        public async Task<IResult> Update(ProfessionUpdateDto professionUpdateDto)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionUpdateDto.Id);

            if (profession != null)
            {
                profession.ProfessionName = professionUpdateDto.ProfessionName;
                profession.IsActive = professionUpdateDto.IsActive;
                profession.ModifiedDate = DateTime.Now;

                await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Vəzifə uğurla yeniləndi!");
            }

            return new Result(ResultStatus.Error, "Vəzifə tapılmadı!");
        }
    }
}
