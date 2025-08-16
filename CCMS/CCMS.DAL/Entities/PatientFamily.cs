using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CCMS.DAL.Entities
{
    [Table("Patient_FamilyMember", Schema = "ccms")]
    [PrimaryKey("PatientId", "FamilyMemberId")]
    public class PatientFamily : Base
    {
        [Required]
        [MaxLength(100)]
        public string Relationship { get; private set; }
        public virtual Patient Patient { get; private set; }
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; private set; }
        public virtual FamilyMember FamilyMember { get; private set; }
        [Required]
        [ForeignKey("FamilyMember")]
        public int FamilyMemberId { get; private set; }

        //public PatientFamily() : base() { }
        public PatientFamily(string relationship, int patientId, int familyMemberId, string createdBy)
            : base(createdBy)
            => Set(relationship, patientId, familyMemberId);

        private void Set(string relationship, int patientId, int familyMemberId)
        {
            Relationship = relationship;
            PatientId = patientId;
            FamilyMemberId = familyMemberId;
        }

        public void Edit(string relationship, int patientId, int familyMemberId, string modifiedBy)
        {
            Set(relationship, patientId, familyMemberId);
            SaveModification(modifiedBy);
        }
    }
}
