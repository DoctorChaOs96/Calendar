namespace Calendar.CalendarConsole.Helper
{
    internal class ConsoleOptionSelector<TOptionKey>
    {
        private const string OptionRowStrTemplate = "[{0}] - {1}"; // 0 - cursor char, 1 - option text;
        private const string SeletedOptionCursor = "█";
        private const string NotSeletedOptionCursor = " ";

        private readonly ConsoleOptions<TOptionKey> _options;
        private int _selectedOptionIndex;

        public ConsoleOptionSelector(ConsoleOptions<TOptionKey> options)
        {
            _options = options;
            _selectedOptionIndex = 0;
        }

        public TOptionKey ChooseOptions(TOptionKey defaultOptionKey)
        {
            do
            {
                Console.Clear();

                PrintState();

                var key = Console.ReadKey();

                if(key.Key == ConsoleKey.DownArrow)
                {
                    SelectNext();
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    SelectPrevious();
                } else if (key.Key == ConsoleKey.Enter)
                {
                    return _options.Options[_selectedOptionIndex].Key;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return defaultOptionKey;
                }
            }
            while (true);
        }

        private void PrintState()
        {
            if (!string.IsNullOrWhiteSpace(_options.Title))
            {
                Console.WriteLine(_options.Title);
            }

            for(var optionIdnex = 0; optionIdnex < _options.Options.Length; optionIdnex++)
            {
                var cursor = optionIdnex == _selectedOptionIndex ? SeletedOptionCursor : NotSeletedOptionCursor;

                Console.WriteLine(string.Format(OptionRowStrTemplate, cursor, _options.Options[optionIdnex].Value));
            }
        }

        private void SelectNext()
        {
            _selectedOptionIndex++;

            if(_selectedOptionIndex >= _options.Options.Length)
            {
                _selectedOptionIndex = _options.Options.Length - 1;
            }
        }

        private void SelectPrevious()
        {
            _selectedOptionIndex--;

            if (_selectedOptionIndex < 0)
            {
                _selectedOptionIndex = 0;
            }
        }
    }
}
