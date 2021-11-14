using PandemicTDD;
using System;

namespace PandemicTDDTests.Running
{
    public class GameStateConsoleObserver : IObserveGameState
    {
        public GameStateConsoleObserver()
        {
        }

        public string LastErrorReceived { get; private set; }
        public string LastActionReceveived { get; private set; }

        public void Action(string ActionMessage)
        {
            LastActionReceveived = ActionMessage;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Action:" + ActionMessage);
        }

        public void Error(string ErrorMessage)
        {
            LastErrorReceived = ErrorMessage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error:" + ErrorMessage);
        }
    }
}