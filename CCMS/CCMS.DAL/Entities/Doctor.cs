using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Doctor", Schema = "ccms")]
    public class Doctor : Employee
    {
        public string name { get; private set; }
        public Specialization major { get; private set; }
        //Rating in the pdf of tasks says that Mazen will impelement it so when he does change this rating field to the corresponding class
        public Rating rating { get; private set; }
        //public List<Patient>? patients { get; private set; }
        //public List<Room>? rooms { get; private set; }
        //ternary relationship book
        public List<Book> Books { get; private set; }
        public Doctor(Specialization major)
        {
            name = GetFullName();
            this.major = major;
            rating = Rating.Neutral;
        }
        public string GetFullName()
        {
            return $"{FName} {MidName} {LName}";
        }
        public void EditRating(Rating rating)
        {
            this.rating = rating;
        }
        public void Edit(string name, Specialization major)
        {
            this.name = name;
            this.major = major;
        }
    }
}