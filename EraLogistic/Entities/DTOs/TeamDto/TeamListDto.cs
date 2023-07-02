using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.TeamDto
{
    public  class TeamListDto : DtoGetBase
    {
        public IList<Team> Teams { get; set; }
    }
}
