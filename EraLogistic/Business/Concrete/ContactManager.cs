using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactDto;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ContactPostDto contactPostDto)
        {
            if (contactPostDto != null)
            {
                var contact = _mapper.Map<Contact>(contactPostDto);

                await _unitOfWork.Contacts.AddAsync(contact);
                await _unitOfWork.SaveAsync();

                ContactDto contactGet = _mapper.Map<ContactDto>(contact);

                return new Result(ResultStatus.Success, $"{contactPostDto.Name} {contactPostDto.Surname}, mesajınız uğurla göndərildi!");
            }

            return new Result(ResultStatus.Error, "Mesaj göndərilmədi!");
        }

        public async Task<IResult> Delete(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                contact.IsDeleted = true;
                await _unitOfWork.Contacts.UpdateAsync(contact);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Mesajınız uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Mesaj tapılmadı!");
        }

        public async Task<IDataResult<ContactDto>> Get(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                return new DataResult<ContactDto>(ResultStatus.Success, new ContactDto
                {
                    Contact = contact,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactDto>(ResultStatus.Error, "Mesaj tapılmadı!", null);
        }

        public async Task<IDataResult<ContactListDto>> GetAll()
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync();

            if (contacts.Count >= 0)
            {
                return new DataResult<ContactListDto>(ResultStatus.Success, new ContactListDto
                {
                    Contacts = contacts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactListDto>(ResultStatus.Error, "Mesajlar tapılmadı!", null);
        }

        public async Task<IDataResult<ContactListDto>> GetAllByDeleted()
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync(x => x.IsDeleted);

            if (contacts.Count >= 0)
            {
                return new DataResult<ContactListDto>(ResultStatus.Success, new ContactListDto
                {
                    Contacts = contacts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactListDto>(ResultStatus.Error, "Mesajlar tapılmadı!", null);
        }

        public async Task<IDataResult<ContactListDto>> GetAllByNonDeleted()
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync(x => !x.IsDeleted);

            if (contacts.Count >= 0)
            {
                return new DataResult<ContactListDto>(ResultStatus.Success, new ContactListDto
                {
                    Contacts = contacts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactListDto>(ResultStatus.Error, "Mesajlar tapılmadı!", null);
        }

        public async Task<IResult> HardDelete(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                await _unitOfWork.Contacts.DeleteAsync(contact);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Mesajınız uğurla silindi!");
            }

            return new Result(ResultStatus.Error, "Mesaj tapılmadı!");
        }

        public async Task<IResult> Restore(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                contact.IsDeleted = false;
                await _unitOfWork.Contacts.UpdateAsync(contact);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Mesajın uğurla geri qaytarıldı!");
            }

            return new Result(ResultStatus.Error, "Mesaj tapılmadı!");
        }
    }
}
