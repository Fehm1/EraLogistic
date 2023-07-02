using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.TeamDto
{
    public class TeamDto : DtoGetBase
    {
        public Team Team { get; set; }
    }
}
