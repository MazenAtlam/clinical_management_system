using System;

namespace CCMS.BLL.ModelVM.Scan
{
    public class ScanDTO
    {
        public int Id { get; set; }
        public string ScanType { get; set; }
        public string ScanTech { get; set; }
        public string? Results { get; set; }
        public DateTime SDate { get; set; }
        public int PatientId { get; set; }
    }
}
