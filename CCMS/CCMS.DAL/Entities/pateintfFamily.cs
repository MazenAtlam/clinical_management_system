using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("PateintfFamilyJoin", Schema = "ccms")]
    public class PateintFamilyJoin : Base
    {
        //add composite key
        public int Id { get; private set; }
        public string Relationship { get; private set; }

        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public FamilyMember FamilyMember { get; set; }
        [ForeignKey("FamilyMember")]
        public int FamilyMemberId { get; set; }

        public void Edit(string relationship, int patientId, int familyMemberId)
        {
            this.Relationship = relationship;
            this.PatientId = patientId;
            this.FamilyMemberId = familyMemberId;
            this.ModifiedOn = DateTime.Now;
        }
    }
}
