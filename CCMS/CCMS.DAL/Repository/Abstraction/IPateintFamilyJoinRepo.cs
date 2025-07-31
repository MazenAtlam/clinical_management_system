using CCMS.DAL.Entities;
using System.Collections.Generic;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPateintFamilyJoinRepo
    {
        bool Create(PateintFamilyJoin join);
        PateintFamilyJoin GetById(int id);
        List<PateintFamilyJoin> GetAll();
        bool Delete(int id);
        bool Update(PateintFamilyJoin joinKeys);
    }
}