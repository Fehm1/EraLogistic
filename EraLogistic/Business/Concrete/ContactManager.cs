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

        public async Task<IDataResult<ContactDto>> Add(ContactPostDto contactPostDto)
        {
            if (contactPostDto != null)
            {
                var contact = _mapper.Map<Contact>(contactPostDto);

                var addedcontact = await _unitOfWork.Contacts.AddAsync(contact);
                await _unitOfWork.SaveAsync();

                ContactDto contactGet = _mapper.Map<ContactDto>(contact);

                return new DataResult<ContactDto>(ResultStatus.Success, $"{contactPostDto.Name} {contactPostDto.Surname}, mesajınız uğurla göndərildi!", new ContactDto
                {
                    Contact = addedcontact,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{contactPostDto.Name} {contactPostDto.Surname}, mesajınız uğurla göndərildi!"
                });
            }

            return new DataResult<ContactDto>(ResultStatus.Error, "Mesaj göndərilmədi!", new ContactDto
            {
                Contact = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesaj göndərilmədi!"
            });
        }

        public async Task<IDataResult<ContactDto>> Delete(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                contact.IsDeleted = true;
                await _unitOfWork.Contacts.UpdateAsync(contact);
                await _unitOfWork.SaveAsync();

                return new DataResult<ContactDto>(ResultStatus.Success, "Mesaj uğurla silindi!", new ContactDto
                {
                    Contact = contact,
                    ResultStatus = ResultStatus.Success,
                    Message = "Mesaj uğurla silindi!"
                });
            }

            return new DataResult<ContactDto>(ResultStatus.Error, "Mesaj tapılmadı!", new ContactDto
            {
                Contact = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesaj tapılmadı!"
            });
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
            return new DataResult<ContactDto>(ResultStatus.Error, "Mesaj tapılmadı!", new ContactDto
            {
                Contact = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesaj tapılmadı!"
            });
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
            return new DataResult<ContactListDto>(ResultStatus.Error, "Mesajlar tapılmadı!", new ContactListDto
            {
                Contacts = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesajlar tapılmadı!"
            });
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
            return new DataResult<ContactListDto>(ResultStatus.Error, "Mesajlar tapılmadı!", new ContactListDto
            {
                Contacts = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesajlar tapılmadı!"
            });
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
            return new DataResult<ContactListDto>(ResultStatus.Error, "Mesajlar tapılmadı!", new ContactListDto
            {
                Contacts = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesajlar tapılmadı!"
            });
        }

        public async Task<IDataResult<ContactDto>> HardDelete(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                var deletedContact = await _unitOfWork.Contacts.DeleteAsync(contact);
                await _unitOfWork.SaveAsync();

                return new DataResult<ContactDto>(ResultStatus.Success, "Mesajınız uğurla silindi!", new ContactDto
                {
                    Contact = deletedContact,
                    ResultStatus = ResultStatus.Success,
                    Message = "Mesajınız uğurla silindi!"
                });
            }

            return new DataResult<ContactDto>(ResultStatus.Error, "Mesaj tapılmadı!", new ContactDto
            {
                Contact = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesaj tapılmadı!"
            });
        }

        public async Task<IDataResult<ContactDto>> Read(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                contact.IsRead = true;
                var readedContact = await _unitOfWork.Contacts.UpdateAsync(contact);
                await _unitOfWork.SaveAsync();

                return new DataResult<ContactDto>(ResultStatus.Success, "Mesajın uğurla oxundu!", new ContactDto
                {
                    Contact = readedContact,
                    ResultStatus = ResultStatus.Success,
                    Message = "Mesajın uğurla oxundu!"
                });
            }

            return new DataResult<ContactDto>(ResultStatus.Error, "Mesaj tapılmadı!", new ContactDto
            {
                Contact = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesaj tapılmadı!"
            });
        }

        public async Task<IDataResult<ContactDto>> Restore(int contactId)
        {
            var contact = await _unitOfWork.Contacts.GetAsync(x => x.Id == contactId);

            if (contact != null)
            {
                contact.IsDeleted = false;
                var restoredContact = await _unitOfWork.Contacts.UpdateAsync(contact);
                await _unitOfWork.SaveAsync();

                return new DataResult<ContactDto>(ResultStatus.Success, "Mesajın uğurla geri qaytarıldı!", new ContactDto
                {
                    Contact = restoredContact,
                    ResultStatus = ResultStatus.Success,
                    Message = "Mesajın uğurla geri qaytarıldı!"
                });
            }

            return new DataResult<ContactDto>(ResultStatus.Error, "Mesaj tapılmadı!", new ContactDto
            {
                Contact = null,
                ResultStatus = ResultStatus.Error,
                Message = "Mesaj tapılmadı!"
            });
        }
    }
}
