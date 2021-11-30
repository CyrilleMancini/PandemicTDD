using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDDApplication;
using PandemicTDDApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonTestsTools
{

    public class PandemicConsole : IPandemicView, IObserveGameState
    {
        IPandemicRessource Ressources;

        CliItem Player = new CliItem(0, 0, ConsoleColor.Blue, ConsoleColor.Black);
        CliItem Location = new CliItem(0, 1, ConsoleColor.White, ConsoleColor.Black);
        CliItem LocationTown = new CliItem(0, 2, ConsoleColor.Blue, ConsoleColor.Black);
        CliItem ActionToPlay = new CliItem(0, 3, ConsoleColor.White, ConsoleColor.Black);
        CliItem ActionsList = new CliItem(0, 4, ConsoleColor.Yellow, ConsoleColor.Black);
        CliItem Destinations = new CliItem(20, 10, ConsoleColor.Yellow, ConsoleColor.Black);
        CliItem DestinationsList = new CliItem(10, 11, ConsoleColor.Yellow, ConsoleColor.Black);

        CliItem ActionList = new CliItem(30, 22, ConsoleColor.White, ConsoleColor.Cyan);
        CliItem ErrorList = new CliItem(30, 25, ConsoleColor.White, ConsoleColor.Red);
        CliItem ResultList = new CliItem(30, 28, ConsoleColor.White, ConsoleColor.Green);
        CliItem AskDisease = new CliItem(30, 28, ConsoleColor.White, ConsoleColor.Green);


        CliItem PlayerCards = new CliItem(60, 1, ConsoleColor.White, ConsoleColor.Cyan);
        CliItem PLayerCardsDiscard = new CliItem(70, 1, ConsoleColor.White, ConsoleColor.Cyan);


        public PandemicConsole(IPandemicRessource ressources)
        {
            Ressources = ressources;
        }


        Dictionary<string, Action> AvailableActions = new();

        public void ClearActions() => AvailableActions.Clear();

        public void AddPlayerAction(string ActionName, Action action) => AvailableActions[ActionName] = action;

        public void DisplayPlayer(Player current)
        {
            Player.Write(Ressources.PlayerYourTurn(current));
        }

        public void AskAction()
        {
            Console.WriteLine("Quelle action jouer ? ");
            string line = Console.ReadLine();
            if (AvailableActions.ContainsKey(line))
                AvailableActions[line]?.Invoke();
        }

        public void DisplayActions()
        {
            ActionToPlay.Write("Actions Disponibles.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            ActionsList.WriteList(AvailableActions.Keys.ToArray());
        }

        public void DisplayBoard(Board board)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DisplayCardStack(board);
            DisplayDiscardCardStack(board);
        }

        private void DisplayDiscardCardStack(Board board) => PLayerCardsDiscard.WriteList(board.PlayerDiscardCardStack.Select(c => "====").ToArray());

        private void DisplayCardStack(Board board) => PlayerCards.WriteList(board.PlayerCardStack.Select(c => "====").ToArray());

        public void DisplayInstruction(string instruction)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(instruction);
        }

        public string AskDestinationAmong(Town[] TownsDestinations)
        {
            Destinations.Write("Quelle destination aller ?");
            ListItem[] towns = TownsDestinations.Select(t => (ListItem)SelectTownByColor(new ListItem()
            {
                Value = $"{t.Name} {t.Country}"
            }, t)).ToArray();

            DestinationsList.WriteList(towns);
            string line = Console.ReadLine();
            return line;
        }

        public void DisplayLocation(Town town)
        {
            Location.Write($"Vous êtes situé à : ");
            SelectTownByColor(LocationTown, town);
            LocationTown.Write($"{town.Name}, {town.Country}");
        }

        private static IColorable SelectTownByColor(IColorable item, Town town)
        {
            switch (town.Color)
            {
                case DiseaseColor.Black:
                    item.ForegroundColor = ConsoleColor.Black;
                    item.BackgroundColor = ConsoleColor.White;
                    break;
                case DiseaseColor.Red:
                    item.ForegroundColor = ConsoleColor.Red;
                    item.BackgroundColor = ConsoleColor.Black;
                    break;
                case DiseaseColor.Yellow:
                    item.ForegroundColor = ConsoleColor.Yellow;
                    item.BackgroundColor = ConsoleColor.Black;
                    break;
                case DiseaseColor.Blue:
                    item.ForegroundColor = ConsoleColor.Blue;
                    item.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
            return item;
        }

        public void Error(string ErrorMessage) => ErrorList.WriteBlockingBox(ErrorMessage);

        public void Action(string ActionMessage) => ActionList.WriteBlockingBox(ActionMessage);

        public void Result(string message) => ResultList.WriteBlockingBox(message);


        public DiseaseColor AskDiseaseColor()
        {
            AskDisease.WriteBox("Quelle maladie ? 1.Rouge, 2.Bleu, 3.Noir, 4.Jaune");
            ConsoleKey c = Console.ReadKey().Key;
            switch (c)
            {
                case ConsoleKey.NumPad1:
                    return DiseaseColor.Red;
                case ConsoleKey.NumPad2:
                    return DiseaseColor.Blue;
                case ConsoleKey.NumPad3:
                    return DiseaseColor.Black;
                case ConsoleKey.NumPad4:
                    return DiseaseColor.Yellow;
            }
            throw new InvalidInputException("Maladie inconnue.");

        }
    }
}