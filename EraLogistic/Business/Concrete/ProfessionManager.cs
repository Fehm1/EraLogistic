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

        public async Task<IDataResult<ProfessionDto>> Add(ProfessionPostDto professionPostDto)
        {
            if (professionPostDto != null)
            {
                var profession = _mapper.Map<Profession>(professionPostDto);

                var addedProfession = await _unitOfWork.Professions.AddAsync(profession);
                await _unitOfWork.SaveAsync();

                ProfessionDto professionGetDto = _mapper.Map<ProfessionDto>(profession);

                return new DataResult<ProfessionDto>(ResultStatus.Success, $"{professionPostDto.ProfessionName} uğurla əlavə olundu!", new ProfessionDto
                {
                    Profession = addedProfession,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{professionPostDto.ProfessionName} uğurla əlavə olundu!"
                });
            }

            return new DataResult<ProfessionDto>(ResultStatus.Error, "Vəzifə əlavə olunmadı!", new ProfessionDto
            {
                Profession = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifə əlavə olunmadı!"
            });
        }

        public async Task<IDataResult<ProfessionDto>> Delete(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id ==  professionId);

            if (profession != null)
            {
                profession.IsDeleted = true;
                var updatedProfession = await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new DataResult<ProfessionDto>(ResultStatus.Success, $"{updatedProfession.ProfessionName} uğurla silindi!", new ProfessionDto
                {
                    Profession = updatedProfession,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedProfession.ProfessionName} uğurla silindi!"
                });
            }

            return new DataResult<ProfessionDto>(ResultStatus.Error, "Vəzifə tapılmadı!", new ProfessionDto
            {
                Profession = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifə tapılmadı!"
            });
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
            return new DataResult<ProfessionDto>(ResultStatus.Error, "Vəzifə tapılmadı!", new ProfessionDto
            {
                Profession = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifə tapılmadı!"
            });
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
            return new DataResult<ProfessionListDto>(ResultStatus.Error, "Vəzifələr tapılmadı!", new ProfessionListDto
            {
                Professions = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifələr tapılmadı!"
            });
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
            return new DataResult<ProfessionListDto>(ResultStatus.Error, "Vəzifələr tapılmadı!", new ProfessionListDto
            {
                Professions = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifələr tapılmadı!"
            });
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
            return new DataResult<ProfessionListDto>(ResultStatus.Error, "Vəzifələr tapılmadı!", new ProfessionListDto
            {
                Professions = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifələr tapılmadı!"
            });
        }

        public async Task<IDataResult<ProfessionUpdateDto>> GetUpdateDto(int professionId)
        {
            var result = await _unitOfWork.Professions.AnyAsync(c => c.Id == professionId);
            if (result)
            {
                var profession = await _unitOfWork.Professions.GetAsync(c => c.Id == professionId);
                var professionUpdateDto = _mapper.Map<ProfessionUpdateDto>(profession);
                return new DataResult<ProfessionUpdateDto>(ResultStatus.Success, professionUpdateDto);
            }
            else
            {
                return new DataResult<ProfessionUpdateDto>(ResultStatus.Error, "Vəzifə tapılmadı!", null);
            }
        }

        public async Task<IDataResult<ProfessionDto>> HardDelete(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId);

            if (profession != null)
            {
                var deletedProfession = await _unitOfWork.Professions.DeleteAsync(profession);
                await _unitOfWork.SaveAsync();

                return new DataResult<ProfessionDto>(ResultStatus.Success, $"{deletedProfession.ProfessionName} vəzifəsi uğurla silindi!", new ProfessionDto
                {
                    Profession = deletedProfession,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedProfession.ProfessionName} vəzifəsi uğurla silindi!"
                });
            }

            return new DataResult<ProfessionDto>(ResultStatus.Error, "Vəzifə tapılmadı!", new ProfessionDto
            {
                Profession = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifə tapılmadı!"
            });
        }

        public async Task<IDataResult<ProfessionDto>> Restore(int professionId)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionId);

            if (profession != null)
            {
                profession.IsDeleted = false;
                var updatedProfession = await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new DataResult<ProfessionDto>(ResultStatus.Success, $"{updatedProfession.ProfessionName} vəzifəsi uğurla geri qaytarıldı!", new ProfessionDto
                {
                    Profession = updatedProfession,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedProfession.ProfessionName} vəzifəsi uğurla geri qaytarıldı!"
                });
            }

            return new DataResult<ProfessionDto>(ResultStatus.Error, "Vəzifə tapılmadı!", new ProfessionDto
            {
                Profession = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifə tapılmadı!"
            });
        }

        public async Task<IDataResult<ProfessionDto>> Update(ProfessionUpdateDto professionUpdateDto)
        {
            var profession = await _unitOfWork.Professions.GetAsync(x => x.Id == professionUpdateDto.Id);

            if (profession != null)
            {
                profession.ProfessionName = professionUpdateDto.ProfessionName;
                profession.IsActive = professionUpdateDto.IsActive;
                profession.ModifiedDate = DateTime.Now;

                var updatedProfession = await _unitOfWork.Professions.UpdateAsync(profession);
                await _unitOfWork.SaveAsync();

                return new DataResult<ProfessionDto>(ResultStatus.Success, $"{updatedProfession.ProfessionName} vəzifəsi uğurla yeniləndi!", new ProfessionDto
                {
                    Profession = updatedProfession,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedProfession.ProfessionName} vəzifəsi uğurla yeniləndi!"
                });
            }

            return new DataResult<ProfessionDto>(ResultStatus.Error, "Vəzifə tapılmadı!", new ProfessionDto
            {
                Profession = null,
                ResultStatus = ResultStatus.Error,
                Message = "Vəzifə tapılmadı!"
            });
        }
    }
}
