using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("LabDoctor", Schema = "ccms")]
    public class LabDoctor : Employee
    {
        public  string name { get; private set; }
        public LabDoctor()
        {
            name = GetFullName();
        }
        public string GetFullName()
        {
            return $"{FName} {MidName} {LName}";
        }
        public void Edit(string name)
        {
            this.name = name;
        }
    }
}