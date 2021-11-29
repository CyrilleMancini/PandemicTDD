using PandemicTDDApplication;
using System;
using System.Collections.Generic;

namespace CommonTestsTools
{
    public class PandemicConsole : IPandemicView
    {

        Dictionary<string, Action> AvailableActions = new();

        public void ClearActions()
        {
            AvailableActions.Clear();
        }

        public void AddPlayerAction(string ActionName, Action action)
        {
            AvailableActions[ActionName] = action;
        }

        public void DisplayInstruction(string instruction)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(instruction);
        }

        public void DisplayActions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string action in AvailableActions.Keys)
            {
                Console.WriteLine($"Jouer: {AvailableActions[action]}");
            }
        }
    }
}