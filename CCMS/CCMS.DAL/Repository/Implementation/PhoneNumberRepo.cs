using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class PhoneNumberRepo : IPhoneNumberRepo
    {
        private readonly CcmsDbContext PhoneNumberDbContext;

        public PhoneNumberRepo(CcmsDbContext db) => PhoneNumberDbContext = db;

        public async Task Add(PhoneNumber phoneNumber) => PhoneNumberDbContext.PhoneNumbers.Add(phoneNumber);

        public async Task Save() => PhoneNumberDbContext.SaveChanges();
    }
}
