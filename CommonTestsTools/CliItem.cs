using System;
using System.Linq;

namespace CommonTestsTools
{
    public class CliItem : IColorable
    {
        public int X { get; set; }

        public int Y { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public ConsoleColor BackgroundColor { get; set; }

        public CliItem(int x, int y, ConsoleColor foreColor, ConsoleColor backColor)
        {
            X = x;
            Y = y;
            ForegroundColor = foreColor;
            BackgroundColor = backColor;
        }

        public void Write(string value)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(value);
        }

        public void WriteList(string[] values)
        {
            if (values.Length == 0) return;
            int maxWidth = values.Max(i => i.Length); ;
            Console.SetCursorPosition(X, Y);
            Console.Write("".PadLeft(maxWidth + 2, '-'));
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            for (int i = 0; i < values.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i + 1);
                Console.Write("|" + (" " + values[i]).PadRight(maxWidth, ' ') + "|");
            }

            Console.WriteLine(" ");
        }

        public void WriteList(ListItem[] values)
        {
            if (values.Length == 0) return;
            
            int maxWidth = values.Max(i => i.Value.Length); ;
            Console.SetCursorPosition(X, Y);
            Console.Write("".PadLeft(maxWidth + 2, '-'));
            for (int i = 0; i < values.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i + 1);
                Console.ForegroundColor = values[i].ForegroundColor;
                Console.BackgroundColor = values[i].BackgroundColor;
                Console.Write("|" + (" " + values[i].Value).PadRight(maxWidth, ' ') + "|");
            }
            Console.WriteLine(" ");
        }

        public void WriteBlockingBox(string Value)
        {
            WriteBox(Value);
            Console.Write("Appuyer sur une touche");
            Console.ReadKey();
        }

        public void WriteBox(string Value)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y);
            Console.Write("".PadLeft(Value.Length + 2, '-'));
            Console.SetCursorPosition(X, Y + 1);
            Console.Write($"|{Value}|");
            Console.SetCursorPosition(X, Y + 2);
            Console.Write("".PadLeft(Value.Length + 2, '-'));
            Console.SetCursorPosition(X, Y + 3);
          
        }
    }
}