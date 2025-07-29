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
        public List<PateintfFamilyJoin> pateintfFamily { get; set; }
    }
}