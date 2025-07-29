namespace CCMS.DAL.Entities
{
    public class BiomedicalEngineer : Employee
    {
        public List<MedicalDevice>? medicalDevices { get; private set; }
        // IMPLEMENT CTOR
        public BiomedicalEngineer()
        {
            
        }
    }
}
