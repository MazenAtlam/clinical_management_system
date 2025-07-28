using CCMS.DAL.Entities.InnerClasses;

namespace CCMS.DAL.Entities
{
    public class Book : Base
    {
        public int Id { get; private set; }
       // public Bill BillId { get; private set; }
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
