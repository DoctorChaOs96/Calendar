using Calendar.Contracts;

namespace Calendar.Domain
{
    public class RoomService
    {
        public Room Create(string name)
        {
            using(var storage = new Storage())
            {
                var room = new Room(Guid.NewGuid(), name);

                storage.Rooms.Add(room);
                storage.SaveChanges();

                return room;
            }
        }

        public Room Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
