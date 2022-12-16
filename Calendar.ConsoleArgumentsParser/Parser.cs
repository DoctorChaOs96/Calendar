using Calendaer.ConsoleArgumentsParser;

namespace Calendar.ConsoleArgumentsParser
{
    public class Parser
    {
        public static CalendarConsoleOption Parse(string[] args)
        {
            if (args == null || args.Length != 2) return CalendarConsoleOption.NotSpecified;

            if (args[0] == "-m")
            {
                if (string.Equals(args[1], nameof(AccessMode.Read), StringComparison.OrdinalIgnoreCase))
                {
                    return CalendarConsoleOption.ReadAccess;
                }
                else if (string.Equals(args[1], nameof(AccessMode.Write), StringComparison.OrdinalIgnoreCase))
                {
                    return CalendarConsoleOption.WriteAccess;
                }
            }

            return CalendarConsoleOption.NotSpecified;
        }
    }
}
