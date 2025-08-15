using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class AddressRepo : IAddressRepo
    {
        private readonly CcmsDbContext AddressDbContext;

        public AddressRepo(CcmsDbContext db) => AddressDbContext = db;

        public async Task Add(Address address) => AddressDbContext.Addresses.Add(address);

        public async Task Save() => AddressDbContext.SaveChanges();
    }
}
