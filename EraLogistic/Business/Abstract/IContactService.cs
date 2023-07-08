using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactDto;

namespace Business.Abstract
{
    public interface IContactService
    {

        Task<IDataResult<ContactDto>> Get(int contactId);
        Task<IDataResult<ContactListDto>> GetAll();
        Task<IDataResult<ContactListDto>> GetAllByNonDeleted();
        Task<IDataResult<ContactListDto>> GetAllByDeleted();
        Task<IDataResult<ContactDto>> Add(ContactPostDto contactPostDto);
        Task<IDataResult<ContactDto>> Restore(int contactId);
        Task<IDataResult<ContactDto>> Delete(int contactId);
        Task<IDataResult<ContactDto>> HardDelete(int contactId);
        Task<IDataResult<ContactDto>> Read(int contactId);
    }
}
