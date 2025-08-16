using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("MedicalHistory", Schema = "ccms")]
    public class MedicalHistory : Base
    {
        public int Id { get; private set; }
        [Required]
        public bool IsAcceptable { get; private set; }
        [Required]
        [MaxLength(100)]
        public string DiseaseName { get; private set; }
        // Navigation
        public virtual Patient Patient { get; set; }
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        //public MedicalHistory() : base() { }
        public MedicalHistory(bool isAcceptable, string diseaseName, int patientId, string createdBy)
            : base(createdBy)
            => Set(isAcceptable, diseaseName, patientId);

        private void Set(bool isAcceptable, string diseaseName, int patientId)
        {
            IsAcceptable = isAcceptable;
            DiseaseName = diseaseName;
            PatientId = patientId;
        }

        public void Edit(bool isAcceptable, string diseaseName, int patientId, string modifiedBy)
        {
            Set(isAcceptable, diseaseName, patientId);
            SaveModification(modifiedBy);
        }
    }
}