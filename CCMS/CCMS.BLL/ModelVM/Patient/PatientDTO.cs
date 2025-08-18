using CCMS.BLL.ModelVM.Person;
using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Patient
{
    public class PatientDTO : PersonDTO
    {
        public BloodType BloodType { get; set; }
    }
}
