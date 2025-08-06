using CCMS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.BLL.ModelVM.Doctor
{
    public class CreateDoctor
    {
        public string FName { get;  set; }

        [MaxLength(50)]
        public string MidName { get;  set; }

        [Required]
        [MaxLength(50)]
        public string LName { get;  set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        public string SSN { get;  set; }

        [Required]
        public Gender Gender { get;  set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get;  set; }
        public Specialization major { get;  set; }

    }
}
