using CCMS.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Scan", Schema = "ccms")]
    public class Scan : Base
    {
        public int Id { get; private set; }
        [Required]
        public SType ScanType { get; private set; }
        [Required]
        public STech ScanTech { get; private set; }
        [Required]
        // File location or Use file uploader
        [MaxLength(500)] // if file location
        public string? Results { get; private set; }
        [Required]
        public DateTime SDate { get; private set; }
        // Navigation
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual LabDoctor LabDoctor { get; private set; }
        [Required]
        [ForeignKey("LabDoctor")]
        public int LDID { get; private set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Patient Patient { get; private set; }
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; private set; }

        //public Scan() : base() { }
        public Scan(SType scanType, STech scanTech, string results, DateTime sDate, int lDID, int patientId, string createdBy)
            : base(createdBy)
            => Set(scanType, scanTech, results, sDate, lDID, patientId);

        private void Set(SType scanType, STech scanTech, string results, DateTime sDate, int lDID, int patientId)
        {
            ScanType = scanType;
            ScanTech = scanTech;
            Results = results;
            SDate = sDate;
            LDID = lDID;
            PatientId = patientId;
        }

        public void Edit(SType scanType, STech scanTech, string results, DateTime sDate, int lDID, int patientId, string modifiedBy)
        {
            Set(scanType, scanTech, results, sDate, lDID, patientId);
            SaveModification(modifiedBy);
        }
    }
}