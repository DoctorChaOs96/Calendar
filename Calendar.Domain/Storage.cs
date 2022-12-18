using Calendar.Contracts;
using System.Text.Json;

namespace Calendar.Domain
{
    internal class Storage : IDisposable
    {
        private readonly string _dbPath;

        private string FullPath => _dbPath + "db.json";

        public Storage(string path = "Storage/")
        {
            _dbPath = path;

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(FullPath))
            {
                File.Create(FullPath).Close();
                File.WriteAllText(FullPath, JsonSerializer.Serialize(new Dump(new List<Room>(0), new List<Event>(0))));
            }

            Refresh();
        }

        public List<Room> Rooms { get; set; }

        public List<Event> Events { get; set; }

        public void SaveChanges()
        {
            var dump = new Dump(Rooms, Events);

            File.WriteAllText(FullPath, JsonSerializer.Serialize<Dump>(dump));
        }

        public void Refresh()
        {
            var dumpText = File.ReadAllText(FullPath);

            var dump = JsonSerializer.Deserialize<Dump>(dumpText);

            if (dump == null)
                throw new InvalidDataException("Dump file is broken.");

            Rooms = dump.Rooms;
            Events = dump.Events;
        }

        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
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
