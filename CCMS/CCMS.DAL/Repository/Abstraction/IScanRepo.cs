using CCMS.DAL.Entities;
using System.Collections.Generic;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IScanRepo
    {
        bool Create(Scan scan);
        Scan GetById(int id);
        List<Scan> GetAll();
        bool Delete(int id);
        bool Update(Scan scan);
    }
}