using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.ContactDto
{
    public class ContactListDto : DtoGetBase
    {
        public IList<Contact> Contacts { get; set; }
    }
}
