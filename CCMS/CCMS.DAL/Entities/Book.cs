using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Book", Schema = "ccms")]
    public class Book : Base
    {
        public int Id { get; private set; }
        [Required]
        public double Price { get; private set; }
        // File location, Use file uploader, or Use image uploader
        [MaxLength(500)] // if file location
        public string? Perscription{ get; private set;}
        [Required]
        public DateTime BookDate { get; private set; }
        // Navigation
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Patient Patient { get; private set; }
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; private set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Doctor Doctor { get; private set; }
        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; private set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Room Room { get; private set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        [ForeignKey("Room")]
        public string RNumber { get; private set; } // bbfrrr

        //public Book() : base() { }
        public Book(double price, string? perscription, DateTime bookDate, int patientId, int doctorId, string rNumber, string createdBy)
            : base(createdBy)
            => Set(price, perscription, bookDate, patientId, doctorId, rNumber);

        private void Set(double price, string? perscription, DateTime bookDate, int patientId, int doctorId, string rNumber)
        {
            Price = price;
            Perscription = perscription;
            BookDate = bookDate;
            PatientId = patientId;
            DoctorId = doctorId;
            RNumber = rNumber;
        }

        public void Edit(double price, string? perscription, DateTime bookDate, int patientId, int doctorId, string rNumber, string modifiedBy)
        {
            Set(price, perscription, bookDate, patientId, doctorId, rNumber);
            SaveModification(modifiedBy);
        }
        
    }
}