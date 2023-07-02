using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.ProfessionDto
{
    public class ProfessionDto : DtoGetBase
    {
        public Profession Profession { get; set; }
    }
}
