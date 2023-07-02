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
        Task<IResult> Add(TeamPostDto teamIdPostDto);
        Task<IResult> Update(TeamUpdateDto teamUpdateDto);
        Task<IResult> Restore(int teamId);
        Task<IResult> Delete(int teamId);
        Task<IResult> HardDelete(int teamId);
    }
}
