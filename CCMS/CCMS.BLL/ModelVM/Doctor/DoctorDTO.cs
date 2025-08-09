using CCMS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.BLL.ModelVM.Doctor
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string name { get;  set; }
        public Specialization major { get; set; }
    }
}
