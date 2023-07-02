using AutoMapper;
using Business.Abstract;
using Core.Extentions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.SliderDto;
using Entities.DTOs.TeamDto;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public TeamManager(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IResult> Add(TeamPostDto teamIdPostDto)
        {
            if (teamIdPostDto != null)
            {
                var team = _mapper.Map<Team>(teamIdPostDto);

                if (teamIdPostDto.Image != null)
                {
                    if (!teamIdPostDto.Image.IsImageContent())
                    {
                        return new Result(ResultStatus.Error, "Şəkil formatı daxil edin!");
                    }

                    if (!teamIdPostDto.Image.IsValidImageLength())
                    {
                        return new Result(ResultStatus.Error, "Şəkilin həcmi böyükdür!");
                    }

                    string newImage = teamIdPostDto.Image.SaveImage(_env.WebRootPath, "uploads/Teams");
                }
                else
                {
                    return new Result(ResultStatus.Error, "Şəkil daxil edin!");
                }


                await _unitOfWork.Teams.AddAsync(team);
                await _unitOfWork.SaveAsync();
                TeamGetDto teamGetDto = _mapper.Map<TeamGetDto>(team);

                return new Result(ResultStatus.Success, "Üzv uğurla əlavə olundu!");
            }

            return new Result(ResultStatus.Error, "Məlumatlar əlavə olunmadı!");
        }

        public async Task<IResult> Delete(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);

            if (team != null)
            {
                team.IsDeleted = true;
                await _unitOfWork.Teams.UpdateAsync(team);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Üzv uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Üzv tapılmadı!");
        }

        public async Task<IDataResult<Team>> Get(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);

            if (team != null)
            {
                return new DataResult<Team>(ResultStatus.Success, team);
            }
            return new DataResult<Team>(ResultStatus.Error, "Üzv tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Team>>> GetAll()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync();
            if (teams.Count >= 0)
            {
                return new DataResult<IList<Team>>(ResultStatus.Success, teams);
            }
            return new DataResult<IList<Team>>(ResultStatus.Error, "Üzvlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Team>>> GetAllByDeleted()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(x => x.IsDeleted);
            if (teams.Count >= 0)
            {
                return new DataResult<IList<Team>>(ResultStatus.Success, teams);
            }
            return new DataResult<IList<Team>>(ResultStatus.Error, "Üzvlər tapılmadı!", null);
        }

        public async Task<IDataResult<IList<Team>>> GetAllByNonDeleted()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(x => !x.IsDeleted);
            if (teams.Count >= 0)
            {
                return new DataResult<IList<Team>>(ResultStatus.Success, teams);
            }
            return new DataResult<IList<Team>>(ResultStatus.Error, "Üzvlər tapılmadı!", null);
        }

        public async Task<IResult> HardDelete(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);

            if (team != null)
            {
                await _unitOfWork.Teams.DeleteAsync(team);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Üzv uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Üzv tapılmadı!");
        }

        public async Task<IResult> Restore(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);

            if (team != null)
            {
                team.IsDeleted = false;
                await _unitOfWork.Teams.UpdateAsync(team);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Üzv uğurla geri qaytarıldı!");
            }

            return new Result(ResultStatus.Error, "Üzv tapılmadı!");
        }

        public async Task<IResult> Update(TeamUpdateDto teamUpdateDto)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamUpdateDto.Id);

            if (team != null)
            {
                if (teamUpdateDto.Image != null)
                {
                    if (!teamUpdateDto.Image.IsImageContent())
                    {
                        return new Result(ResultStatus.Error, "Şəkil formatı daxil edin!");
                    }

                    if (!teamUpdateDto.Image.IsValidImageLength())
                    {
                        return new Result(ResultStatus.Error, "Şəkilin həcmi böyükdür!");
                    }

                    string newImage = teamUpdateDto.Image.SaveImage(_env.WebRootPath, "uploads/Teams");
                    team.Image.DeleteImage(_env.WebRootPath, "uploads/Teams");

                    team.Image = newImage;
                }

                team.ProfessionId = teamUpdateDto.ProfessionId;
                team.Fullname = teamUpdateDto.Fullname;
                team.InstagramUrl = teamUpdateDto.InstagramUrl;
                team.FacebookUrl = teamUpdateDto.FacebookUrl;
                team.TwitterUrl = teamUpdateDto.TwitterUrl;
                team.WhatsAppUrl = teamUpdateDto.WhatsAppUrl;
                team.LinkedInUrl = teamUpdateDto.LinkedInUrl;
                team.IsActive = teamUpdateDto.IsActive;
                team.ModifiedDate = DateTime.Now;

                await _unitOfWork.Teams.UpdateAsync(team);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Üzv uğurla yeniləndi!");
            }

            return new Result(ResultStatus.Error, "Üzv tapılmadı!");
        }
    }
}
