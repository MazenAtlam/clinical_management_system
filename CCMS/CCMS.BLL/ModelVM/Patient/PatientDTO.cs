using CCMS.DAL.Entities;
using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Patient
{
    public class PatientDTO
    {
        public PatientDTO()
        {
        }

        public int UID { get; set; }
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string Ssn { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public BloodType BloodType { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Address> Addresses { get; set; }

        public PatientDTO(int uID, string fName, string? midName, string lName, string ssn, Gender gender, DateOnly birthDate, BloodType bloodType, List<PhoneNumber> phoneNumbers, List<Address> addresses)
        {
            UID = uID;
            FName = fName;
            MidName = midName;
            LName = lName;
            Ssn = ssn;
            Gender = gender;
            BirthDate = birthDate;
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
