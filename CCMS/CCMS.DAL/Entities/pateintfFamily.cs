using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("PateintfFamilyJoin", Schema = "ccms")]
    public class PateintfFamilyJoin : Base
    {
        
        public int Id { get; private set; }
        public string Relationship { get; private set; }

        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public FamilyMember FamilyMember { get; set; }
        [ForeignKey("FamilyMember")]
        public int FamilyMemberId { get; set; }

    }
}
