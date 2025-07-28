
namespace CCMS.DAL.Entities.InnerClasses
{
    public class Bill
    {
        public int Id { get;private set; }
        public string item { get; private set; }
        public double price { get; private set; }
        public string? Note { get; private set; }
    }
}
