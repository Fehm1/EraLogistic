using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.ContactDto
{
    public class ContactDto : DtoGetBase
    {
        public Contact Contact { get; set; }
    }
}
