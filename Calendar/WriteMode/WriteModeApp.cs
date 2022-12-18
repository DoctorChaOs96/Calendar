using Calendar.CalendarConsole.Helper;
using Calendar.CalendarConsole.ReadMode;
using Calendar.Contracts;
using Calendar.Domain;

namespace Calendar.CalendarConsole.WriteMode
{
    internal class WriteModeApp : IApp
    {
        private readonly RoomService _roomService = new RoomService();

        public void Run()
        {
            var optionSelector = new ConsoleOptionSelector<WriteModeActions>(new ConsoleOptions<WriteModeActions>("Choose action:", new[]
            {
                new ConsoleOption<WriteModeActions>(WriteModeActions.CreateRoom, "Create a new room"),
                new ConsoleOption<WriteModeActions>(WriteModeActions.BookRoom, "Book some room")
            }));

            do
            {
                WriteModeActions action = optionSelector.ChooseOptions(WriteModeActions.Out);

                switch (action)
                {
                    case WriteModeActions.CreateRoom:
                        var room = CreateRoom();
                        break;
                    case WriteModeActions.BookRoom:
                        //var event1 = BookRoom();
                        break;
                    case WriteModeActions.Out:
                        Console.WriteLine("aSayonara!");
                        return;
                }
            } while (true);
        }
        private Room CreateRoom()
        {
            return _roomService.Create(StringValueReader.ReadNamedValue("Please enter name of the room:"));
        }

        private Event BookRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
