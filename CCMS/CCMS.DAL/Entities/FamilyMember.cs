using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("FamilyMember", Schema = "ccms")]
    public class FamilyMember : Base
    {

        public int Id { get; private set; }
        public string name { get; private set; }
        public Gender Gender { get; private set; }
        public int SSN { get; private set; }
        public string phone { get; private set; }

        //navigation
        public List<PateintFamilyJoin> pateintfFamily { get; set; }

        public void Edit(string name, Gender gender, int ssn, string phone)
        {
            this.name = name;
            this.Gender = gender;
            this.SSN = ssn;
            this.phone = phone;
            //this.ModifiedOn = DateTime.Now;
            // Take the modifyingUser as parameter for the attribute "ModifiedBy", then Use the following line
            // SaveModification(modifyingUser);
        }
    }
}