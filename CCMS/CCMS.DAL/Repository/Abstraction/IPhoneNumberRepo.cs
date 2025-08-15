using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPhoneNumberRepo
    {
        public Task Add(PhoneNumber phoneNumber);
        public Task Save();
    }
}
