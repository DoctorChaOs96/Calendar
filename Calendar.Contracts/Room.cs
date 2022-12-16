namespace Calendar.Contracts
{
    public class Room
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Room(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
