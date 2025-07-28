using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Entities
{
    [Table("EmpSlot", Schema = "ccms")]
    public  class EmpSlot
    {
        //NEED COMPOSITE KEY IN FLUENT API
        [ForeignKey("Employee")]
        public int empID { get; private set; }
        [ForeignKey("WorkingSlot")]
        public int slotID { get; private set; }
    }
}
