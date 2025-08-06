using CCMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IBiomedicalEngineerRepo
    {
        bool Create(BiomedicalEngineer biomedicalEngineer);
        BiomedicalEngineer GetById(int id);
        List<BiomedicalEngineer> GetAll();
        bool Delete(int id);
        bool Update(BiomedicalEngineer biomedicalEngineer);
    }
}
