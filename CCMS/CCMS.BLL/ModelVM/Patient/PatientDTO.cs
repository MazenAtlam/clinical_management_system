using CCMS.BLL.ModelVM.Person;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Patient
{
    public class PatientDTO : PersonDTO
    {
        // ALL CONSTRUCTORS SHOULD BE REMOVED

        public PatientDTO()
        {
        }

        public BloodType BloodType { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Address> Addresses { get; set; }

        public PatientDTO(int uID, string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, PersonType pType, BloodType bloodType, List<PhoneNumber> phoneNumbers, List<Address> addresses)
        {
            UID = uID;
            FName = fName;
            MidName = midName;
            LName = lName;
            Ssn = ssn;
            Gender = gender;
            BirthDate = birthDate;
            PType = pType;
            BloodType = bloodType;
            PhoneNumbers = phoneNumbers;
            Addresses = addresses;
        }
        public string GetFullName()
        {
            return FName + " " + MidName + " " + LName;
        }
    }
}
