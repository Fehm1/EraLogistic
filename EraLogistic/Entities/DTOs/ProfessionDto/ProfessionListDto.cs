using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.ProfessionDto
{
    public class ProfessionListDto : DtoGetBase
    {
        public IList<Profession> Professions { get; set;}
    }
}
