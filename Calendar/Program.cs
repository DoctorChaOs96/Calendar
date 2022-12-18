using Calendar.CalendarConsole.ReadMode;
using Calendar.CalendarConsole.WriteMode;
using Calendar.ConsoleArgumentsParser;
using System;

namespace Calendar.CalendarConsole
{
    internal class Program
    {
        /*
            create a Calendar that will help users to book a room for a meeting (like Outlook). Create three projects:
            Calendar.CalendarConsole - user interface
            Calendar.Domain (BLL) - application logic
            Calendar.Contracts (Entities) - models
            create two application modes: readonly and RW mode.
            readonly mode will provide an interface to view bookings only
            RW mode enables adding new rooms and booking meetings
            control application mode using command line arguments. Use command line parser to parse arguments (e.g., https://github.com/commandlineparser/commandline) 
            use a file to dump data (use serialization format from here) - JsonSerializer
            describe models in contracts
            based on command line argument render different user interface in the console
            interact with the user using the console
            create a method to add room
            create a method to show all rooms
            create methods to dump data to/from file
            create a method to book a meeting
            forbid to book a meeting at the same room at the same time
        */

        static void Main(string[] args)
        {
            var option = Parser.Parse(args);

            IApp app;

            switch (option.AccessMode)
            {
                default:
                case Calendaer.ConsoleArgumentsParser.AccessMode.Read:
                    app = new ReadModeApp();
                    break;
                case Calendaer.ConsoleArgumentsParser.AccessMode.Write:
                    app = new WriteModeApp();
                    break;
            }

            app.Run();

            Console.ReadKey();
        }
    }
}