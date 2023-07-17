using AutoMapper;
using Business.Abstract;
using Core.Extentions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public async Task<IDataResult<TeamDto>> Add(TeamPostDto teamIdPostDto)
        {
            if (teamIdPostDto != null)
            {
                var team = _mapper.Map<Team>(teamIdPostDto);

                if (teamIdPostDto.Image != null)
                {
                    if (!teamIdPostDto.Image.IsImageContent())
                    {
                        return new DataResult<TeamDto>(ResultStatus.Error, "Şəkil formatı daxil edin!", new TeamDto
                        {
                            Team = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkil formatı daxil edin!"
                        });
                    }

                    if (!teamIdPostDto.Image.IsValidImageLength())
                    {
                        return new DataResult<TeamDto>(ResultStatus.Error, "Şəkilin həcmi böyükdür!", new TeamDto
                        {
                            Team = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkilin həcmi böyükdür!"
                        });
                    }

                    string newImage = teamIdPostDto.Image.SaveImage(_env.WebRootPath, "uploads/Teams");
                    team.Image = newImage;
                }
                else
                {
                    return new DataResult<TeamDto>(ResultStatus.Error, "Şəkil daxil edin!", new TeamDto
                    {
                        Team = null,
                        ResultStatus = ResultStatus.Error,
                        Message = "Şəkil daxil edin!"
                    });
                }


                var addedTeam = await _unitOfWork.Teams.AddAsync(team);
                await _unitOfWork.SaveAsync();
                TeamDto teamGetDto = _mapper.Map<TeamDto>(team);

                return new DataResult<TeamDto>(ResultStatus.Success, $"{addedTeam.Fullname} üzvü uğurla əlavə olundu!", new TeamDto
                {
                    Team = addedTeam,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{addedTeam.Fullname} üzvü uğurla əlavə olundu!"
                });
            }

            return new DataResult<TeamDto>(ResultStatus.Error, "Məlumatlar əlavə olunmadı!", new TeamDto
            {
                Team = null,
                ResultStatus = ResultStatus.Error,
                Message = "Məlumatlar əlavə olunmadı!"
            });
        }

        public async Task<IDataResult<TeamDto>> Delete(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);

            if (team != null)
            {
                team.IsDeleted = true;
                var updatedTeam = await _unitOfWork.Teams.UpdateAsync(team);
                await _unitOfWork.SaveAsync();

                return new DataResult<TeamDto>(ResultStatus.Success, $"{updatedTeam.Fullname} üzvü uğurla silindi!", new TeamDto
                {
                    Team = updatedTeam,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedTeam.Fullname} üzvü uğurla silindi!"
                });
            }

            return new DataResult<TeamDto>(ResultStatus.Error, "Üzv tapılmadı!", new TeamDto
            {
                Team = null,
                ResultStatus = ResultStatus.Error,
                Message = "Üzv tapılmadı!"
            });
        }

        public async Task<IDataResult<TeamDto>> Get(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId, x => x.Profession);

            if (team != null)
            {
                return new DataResult<TeamDto>(ResultStatus.Success, new TeamDto
                {
                    Team = team,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TeamDto>(ResultStatus.Error, "Üzv tapılmadı!", new TeamDto
            {
                Team = null,
                ResultStatus = ResultStatus.Error,
                Message = "Üzv tapılmadı!"
            });
        }

        public async Task<IDataResult<TeamListDto>> GetAll()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(null, x => x.Profession);
            if (teams.Count >= 0)
            {
                return new DataResult<TeamListDto>(ResultStatus.Success, new TeamListDto
                {
                    Teams = teams,
                    ResultStatus= ResultStatus.Success
                });
            }
            return new DataResult<TeamListDto>(ResultStatus.Error, "Üzvlər tapılmadı!", new TeamListDto
            {
                Teams = null,
                ResultStatus= ResultStatus.Error,
                Message = "Üzvlər tapılmadı!"
            });
        }

        public async Task<IDataResult<TeamListDto>> GetAllByDeleted()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(x => x.IsDeleted, x => x.Profession);
            if (teams.Count >= 0)
            {
                return new DataResult<TeamListDto>(ResultStatus.Success, new TeamListDto
                {
                    Teams = teams,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TeamListDto>(ResultStatus.Error, "Üzvlər tapılmadı!", new TeamListDto
            {
                Teams = null,
                ResultStatus = ResultStatus.Error,
                Message = "Üzvlər tapılmadı!"
            });
        }

        public async Task<IDataResult<TeamListDto>> GetAllByNonDeleted()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(x => !x.IsDeleted, x => x.Profession);
            if (teams.Count >= 0)
            {
                return new DataResult<TeamListDto>(ResultStatus.Success, new TeamListDto
                {
                    Teams = teams,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TeamListDto>(ResultStatus.Error, "Üzvlər tapılmadı!", new TeamListDto
            {
                Teams = null,
                ResultStatus = ResultStatus.Error,
                Message = "Üzvlər tapılmadı!"
            });
        }

        public async Task<IDataResult<TeamUpdateDto>> GetUpdateDto(int teamId)
        {
            var result = await _unitOfWork.Teams.AnyAsync(c => c.Id == teamId);
            if (result)
            {
                var team = await _unitOfWork.Teams.GetAsync(c => c.Id == teamId);
                var teamUpdateDto = _mapper.Map<TeamUpdateDto>(team);
                return new DataResult<TeamUpdateDto>(ResultStatus.Success, teamUpdateDto);
            }
            else
            {
                return new DataResult<TeamUpdateDto>(ResultStatus.Error, "Üzv tapılmadı!", null);
            }
        }

        public async Task<IDataResult<TeamDto>> HardDelete(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);

            if (team != null)
            {
                var deletedTeam = await _unitOfWork.Teams.DeleteAsync(team);
                team.Image.DeleteImage(_env.WebRootPath, "uploads/Teams");
                await _unitOfWork.SaveAsync();

                return new DataResult<TeamDto>(ResultStatus.Success, $"{deletedTeam.Fullname} üzvü uğurla silindi!", new TeamDto
                {
                    Team = deletedTeam,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedTeam.Fullname} üzvü uğurla silindi!"
                });
            }

            return new DataResult<TeamDto>(ResultStatus.Error, "Üzv tapılmadı!", new TeamDto
            {
                Team = null,
                ResultStatus = ResultStatus.Error,
                Message = "Üzv tapılmadı!"
            });
        }

        public async Task<IDataResult<TeamDto>> Restore(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);

            if (team != null)
            {
                team.IsDeleted = false;
                var updatedTeam = await _unitOfWork.Teams.UpdateAsync(team);
                await _unitOfWork.SaveAsync();

                return new DataResult<TeamDto>(ResultStatus.Success, $"{updatedTeam.Fullname} üzvü uğurla geri qaytarıldı!", new TeamDto
                {
                    Team = updatedTeam,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedTeam.Fullname} üzvü uğurla geri qaytarıldı!"
                });
            }

            return new DataResult<TeamDto>(ResultStatus.Error, "Üzv tapılmadı!", new TeamDto
            {
                Team = null,
                ResultStatus = ResultStatus.Error,
                Message = "Üzv tapılmadı!"
            });
        }

        public async Task<IDataResult<TeamDto>> Update(TeamUpdateDto teamUpdateDto)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamUpdateDto.Id);

            if (team != null)
            {
                if (teamUpdateDto.ImageFile != null)
                {
                    if (!teamUpdateDto.ImageFile.IsImageContent())
                    {
                        return new DataResult<TeamDto>(ResultStatus.Error, "Şəkil formatı daxil edin!", new TeamDto
                        {
                            Team = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkil formatı daxil edin!"
                        });
                    }

                    if (!teamUpdateDto.ImageFile.IsValidImageLength())
                    {
                        return new DataResult<TeamDto>(ResultStatus.Error, "Şəkilin həcmi böyükdür!", new TeamDto
                        {
                            Team = null,
                            ResultStatus = ResultStatus.Error,
                            Message = "Şəkilin həcmi böyükdür!"
                        });
                    }

                    string newImage = teamUpdateDto.ImageFile.SaveImage(_env.WebRootPath, "uploads/Teams");
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

                var updatedTeam = await _unitOfWork.Teams.UpdateAsync(team);
                await _unitOfWork.SaveAsync();

                return new DataResult<TeamDto>(ResultStatus.Success, $"{updatedTeam.Fullname} üzvü uğurla yeniləndi!", new TeamDto
                {
                    Team = updatedTeam,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{updatedTeam.Fullname} uğurla yeniləndi!"
                });
            }

            return new DataResult<TeamDto>(ResultStatus.Error, "Üzv tapılmadı!", new TeamDto
            {
                Team = null,
                ResultStatus = ResultStatus.Error,
                Message = "Üzv tapılmadı!"
            });
        }
    }
}
