using System;

namespace CommonTestsTools
{
    public interface IColorable
    {
        ConsoleColor ForegroundColor { get; set; }
        ConsoleColor BackgroundColor { get; set; }
    }
}