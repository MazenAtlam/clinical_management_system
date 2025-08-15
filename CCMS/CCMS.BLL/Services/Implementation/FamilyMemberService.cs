using CCMS.BLL.ModelVM.FamilyMember;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System.Collections.Generic;

namespace CCMS.BLL.Services.Implementation
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IFamilyMemberRepo _familyMemberRepo;

        public FamilyMemberService(IFamilyMemberRepo familyMemberRepo)
        {
            _familyMemberRepo = familyMemberRepo;
        }

        public bool Create(CreateFamilyMemberDTO familyMember) => false;

        public bool Update(FamilyMemberDTO familyMember)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public FamilyMember GetById(int id)
        {
            return null;
        }

        public List<FamilyMember> GetAll()
        {
            return new List<FamilyMember>();
        }

        public List<FamilyMember> GetByPatient(int patientId)
        {
            return new List<FamilyMember>();
        }
    }
}
