using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IAddressRepo
    {
        public Task Add(Address address);
        public Task Save();
    }
}
