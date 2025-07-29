using CCMS.DAL.Entities.InnerClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Book", Schema = "ccms")]
    public class Book : Base
    {

        public int Id { get; private set; }
        public double price { get; private set; }
        //public Perscription PerscriptionId { get; private set;}
        public DateTime BookDate { get; private set; }

        //navigation
        public Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public Room Room { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }

    }
}