namespace Calendar.CalendarConsole.Helper
{
    internal class StringValueReader
    {
        public static string ReadNamedValue(string name)
        {
            Console.WriteLine(name);

            return Console.ReadLine();
        }
    }
}
