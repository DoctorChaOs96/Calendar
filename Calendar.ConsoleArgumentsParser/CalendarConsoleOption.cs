namespace Calendaer.ConsoleArgumentsParser
{
    public class CalendarConsoleOption
    {
        public AccessMode AccessMode { get; set; }

        public static CalendarConsoleOption NotSpecified = new CalendarConsoleOption() { AccessMode = AccessMode.NotSpecified };

        public static CalendarConsoleOption ReadAccess = new CalendarConsoleOption() { AccessMode = AccessMode.Read };

        public static CalendarConsoleOption WriteAccess = new CalendarConsoleOption() { AccessMode = AccessMode.Write };
    }
}
