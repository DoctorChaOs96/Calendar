using Calendar.Contracts;
using System.Text.Json;

namespace Calendar.Domain
{
    public class Storage
    {
        private readonly string _dbPath;

        public Storage(string path)
        {
            _dbPath = path;
        }

        public List<Room> Rooms { get; set; }

        public List<Event> Events { get; set; }

        public void SaveChanges()
        {
            var dump = new Dump(Rooms, Events);

            File.WriteAllText(_dbPath, JsonSerializer.Serialize<Dump>(dump));
        }

        public void Refresh()
        {
            var dumpText = File.ReadAllText(_dbPath);

            var dump = JsonSerializer.Deserialize<Dump>(dumpText);

            if (dump == null)
                throw new InvalidDataException("Dump file is broken.");

            Rooms = dump.Rooms;
            Events = dump.Events;
        }

        private class Dump
        {
            public List<Room> Rooms { get; set; }

            public List<Event> Events { get; set; }

            public Dump(List<Room> rooms, List<Event> events)
            {
                Rooms = rooms;
                Events = events;
            }
        }
    }
}
