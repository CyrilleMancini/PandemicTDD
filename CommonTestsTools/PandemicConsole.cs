using PandemicTDD.Materiel;
using PandemicTDDApplication;
using System;
using System.Collections.Generic;

namespace CommonTestsTools
{
    public class PandemicConsole : IPandemicView
    {

        Dictionary<string, Action> AvailableActions = new();

        public void ClearActions() => AvailableActions.Clear();


        public void AddPlayerAction(string ActionName, Action action) => AvailableActions[ActionName] = action;

        public void AskAction()
        {
            Console.WriteLine("Quelle action jouer ? ");
            string line = Console.ReadLine();
            if (AvailableActions.ContainsKey(line))
                AvailableActions[line]?.Invoke();
        }

        public void DisplayActions()
        {

            Console.WriteLine("Actions Disponibles.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string action in AvailableActions.Keys)
            {
                Console.WriteLine($"Jouer: {action}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void DisplayInstruction(string instruction)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(instruction);
        }

        public string AskDestinationAmong(Town[] Destinations)
        {
            Console.WriteLine("Quelle destination aller ?");
            foreach (Town t in Destinations)
            {
                DrawTownByColor(t);
                Console.WriteLine("");
            }
            string line = Console.ReadLine();
            return line;
        }

        public void DisplayLocation(Town town)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Vous êtes situé à : ");
            DrawTownByColor(town);
            Console.WriteLine("");
        }

        private static void DrawTownByColor(Town town)
        {
            switch (town.Color)
            {
                case DiseaseColor.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case DiseaseColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case DiseaseColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case DiseaseColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
            Console.Write($"{town.Name}, {town.Country}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}