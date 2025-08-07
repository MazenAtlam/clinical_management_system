using System;

namespace CCMS.BLL.ModelVM.MedicalHistory
{
    public class MedicalHistoryDTO
    {
        public int Id { get; set; }
        public bool IsAcceptable { get; set; }
        public string DiseaseName { get; set; }
        public int PatientId { get; set; }
    }
}
