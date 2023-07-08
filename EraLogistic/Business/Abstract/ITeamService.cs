using Core.Utilities.Results.Abstract;
using Entities.DTOs.TeamDto;

namespace Business.Abstract
{
    public interface ITeamService
    {
        Task<IDataResult<TeamDto>> Get(int teamId);
        Task<IDataResult<TeamListDto>> GetAll();
        Task<IDataResult<TeamListDto>> GetAllByNonDeleted();
        Task<IDataResult<TeamListDto>> GetAllByDeleted();
        Task<IDataResult<TeamDto>> Add(TeamPostDto teamIdPostDto);
        Task<IDataResult<TeamDto>> Update(TeamUpdateDto teamUpdateDto);
        Task<IDataResult<TeamDto>> Restore(int teamId);
        Task<IDataResult<TeamDto>> Delete(int teamId);
        Task<IDataResult<TeamDto>> HardDelete(int teamId);
    }
}
