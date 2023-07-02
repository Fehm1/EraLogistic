using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.TeamDto;

namespace Business.Abstract
{
    public interface ITeamService
    {
        Task<IDataResult<Team>> Get(int teamId);
        Task<IDataResult<IList<Team>>> GetAll();
        Task<IDataResult<IList<Team>>> GetAllByNonDeleted();
        Task<IDataResult<IList<Team>>> GetAllByDeleted();
        Task<IResult> Add(TeamPostDto teamIdPostDto);
        Task<IResult> Update(TeamUpdateDto teamUpdateDto);
        Task<IResult> Restore(int teamId);
        Task<IResult> Delete(int teamId);
        Task<IResult> HardDelete(int teamId);
    }
}
