namespace Calendar.CalendarConsole.Helper
{
    internal class ConsoleOption<TKey>
    {
        public TKey Key { get; set; }

        public string Value { get; set; }

        public ConsoleOption(TKey key, string value)
        {
            Key = key;
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            var anotherOption = obj as ConsoleOption<TKey>;
            
            if (anotherOption != null)
            {
                return anotherOption.Equals(Key);
            }

            return false;
        }
    }
}
