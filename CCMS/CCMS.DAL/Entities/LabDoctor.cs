using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("LabDoctor", Schema = "ccms")]
    public class LabDoctor : Employee
    {
        public LabDoctor()
        {
            //IMPLEMENT CTOR
        }
    }
}