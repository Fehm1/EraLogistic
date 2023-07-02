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
        Task<IResult> Add(ContactPostDto contactPostDto);
        Task<IResult> Restore(int contactId);
        Task<IResult> Delete(int contactId);
        Task<IResult> HardDelete(int contactId);
    }
}
