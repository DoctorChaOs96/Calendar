namespace Calendar
{
    internal class Program
    {
        /*
            create a Calendar that will help users to book a room for a meeting (like Outlook). Create three projects:
            Calendar.Console - user interface
            Calendar.Domain - application logic
            Calendar.Contracts - models
            create two application modes: readonly and RW mode.
            readonly mode will provide an interface to view bookings only
            RW mode enables adding new rooms and booking meetings
            control application mode using command line arguments. Use command line parser to parse arguments (e.g., third party link)
            use a file to dump data (use serialization format from here)
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
            Console.WriteLine("Hello, World!");
        }
    }
}