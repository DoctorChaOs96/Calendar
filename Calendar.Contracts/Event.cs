namespace Calendar.Contracts
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Event(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
