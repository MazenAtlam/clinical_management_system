using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Doctor", Schema = "ccms")]
    public class Doctor : Employee
    {
        public Specialization major { get; private set; }
        //Rating in the pdf of tasks says that Mazen will impelement it so when he does change this rating field to the corresponding class
        public Rating rating { get; private set; }
        //public List<Patient>? patients { get; private set; }
        //public List<Room>? rooms { get; private set; }
        //ternary relationship book
        public List<Book> Books { get; set; }
        public Doctor(Specialization major)
        {
            this.major = major;
            rating = Rating.Neutral;
        }
        // WRITE THE EDIT METHODS,
        public void EditRating(Rating rating)
        {
            this.rating = rating;
        }
        public void Edit(Book book)
        { 
            
        }
    }
}