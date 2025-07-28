namespace CCMS.DAL.Entities
{
    public class Department : Base
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public List<Room>? rooms { get; private set; }
        public List<Employee>? employees { get; private set; }
    }
}
