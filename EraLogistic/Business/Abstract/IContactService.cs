using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactDto;

namespace Business.Abstract
{
    public interface IContactService
    {

        Task<IDataResult<Contact>> Get(int contactId);
        Task<IDataResult<IList<Contact>>> GetAll();
        Task<IDataResult<IList<Contact>>> GetAllByNonDeleted();
        Task<IDataResult<IList<Contact>>> GetAllByDeleted();
        Task<IResult> Add(ContactPostDto contactPostDto);
        Task<IResult> Restore(int contactId);
        Task<IResult> Delete(int contactId);
        Task<IResult> HardDelete(int contactId);
    }
}
