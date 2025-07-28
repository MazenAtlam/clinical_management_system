using CCMS.DAL.Enums;

namespace CCMS.DAL.Entities
{
    public class Doctor : Employee
    {
        public int id { get; private set; }
        public Specialization major { get; private set; }
        //Rating in the pdf of tasks says that Mazen will impelement it so when he does change this rating field to the corresponding class
        public double rating { get; private set; }
        //public List<Patient>? patients { get; private set; }
        //public List<Room>? rooms { get; private set; }
        public Doctor(Specialization major)
        {
            this.major = major;
        }
    }
}
