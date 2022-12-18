namespace Calendar.CalendarConsole.Helper
{
    internal class ConsoleOptions<TOptionKey>
    {
        public string Title { get; set; }

        public ConsoleOption<TOptionKey>[] Options { get; set; }

        public ConsoleOptions(string title, ConsoleOption<TOptionKey>[] options)
        {
            Title = title;
            Options = options;
        }
    }
}
