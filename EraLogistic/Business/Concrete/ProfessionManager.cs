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

                ProfessionGetDto professionGetDto = _mapper.Map<ProfessionGetDto>(profession);

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

                return new Result(ResultStatus.Success);
            }

            return new Result(ResultStatus.Error, "Məlumatlar silinmədi!");
        }

        public async Task<IDataResult<Profession>> Get(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId, x => x.Teams);

            if (profession != null)
            {
                return new DataResult<Profession>(ResultStatus.Success, profession);
            }
            return new DataResult<Profession>(ResultStatus.Error,"Bu id ilə vəzifə tapılmadı!",null);
        }

        public async Task<IDataResult<IList<Profession>>> GetAll()
        {
            var professions = await _unitOfWork.Professions.GetAllAsync(null, x => x.Teams);
            if (professions.Count >= 0)
            {
                return new DataResult<IList<Profession>>(ResultStatus.Success, professions);
            }
            return new DataResult<IList<Profession>>(ResultStatus.Error, "Vəzifələr tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Profession>>> GetAllByDeleted()
        {
            var professions = await _unitOfWork.Professions.GetAllAsync(x => x.IsDeleted, x => x.Teams);
            if (professions.Count >= 0)
            {
                return new DataResult<IList<Profession>>(ResultStatus.Success, professions);
            }
            return new DataResult<IList<Profession>>(ResultStatus.Error, "Vəzifələr tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Profession>>> GetAllByNonDeleted()
        {
            var professions = await _unitOfWork.Professions.GetAllAsync(x => !x.IsDeleted, x => x.Teams);
            if (professions.Count >= 0)
            {
                return new DataResult<IList<Profession>>(ResultStatus.Success, professions);
            }
            return new DataResult<IList<Profession>>(ResultStatus.Error, "Vəzifələr tapılmadı!", null);
        }

        public async Task<IResult> HardDelete(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId);

            if (profession != null)
            {
                await _unitOfWork.Professions.DeleteAsync(profession);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success);
            }

            return new Result(ResultStatus.Error, "Məlumatlar silinmədi!");
        }

        public async Task<IResult> Restore(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId);

            if (profession != null)
            {
                profession.IsDeleted = false;
                await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success);
            }

            return new Result(ResultStatus.Error, "Məlumatlar geri qaytarılmadı!");
        }

        public async Task<IResult> Update(ProfessionUpdateDto professionUpdateDto)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionUpdateDto.Id);

            if (profession != null)
            {
                profession.ProfessionName = professionUpdateDto.ProfessionName;
                profession.ModifiedDate = DateTime.Now;

                await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{professionUpdateDto.ProfessionName} uğurla yeniləndi!");
            }

            return new Result(ResultStatus.Error, "Vəzifələr tapılmadı!");
        }
    }
}
