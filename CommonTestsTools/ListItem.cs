using System;

namespace CommonTestsTools
{
    public class ListItem : IColorable
    {
        public string Value { get; internal set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
    }
}