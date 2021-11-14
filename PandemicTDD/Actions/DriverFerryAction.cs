using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using System;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    internal class DriverFerryAction : ActionBase
    {
        public const string ErrorDestinationNotLinked = "The Destination is not linked to Player Location.";

        public const string ErrorSameDestinationAndLocation = "Player Location and Destination are the same.";

        private GameState gameState;

        private string Destination;

        private TownSlot playerSlotTown;

        private TownSlot destSlotTown;

        public DriverFerryAction(GameState gameState, string destination)
        {
            this.gameState = gameState;
            this.Destination = destination;
        }


        public override void Execute()
        {
            gameState.CurrentPlayer.Town = destSlotTown.Town;
            gameState.Result($@"Player '{gameState.CurrentPlayer.Name}' moved to {{destSlottown.Town.Name}}");
        }

        public override void Try()
        {
            playerSlotTown = gameState.Board.GetTownSlot(gameState.CurrentPlayer.Town.Name);
            destSlotTown = gameState.Board.GetTownSlot(Destination);

            if (playerSlotTown.Town.Name == Destination)
                throw new ArgumentException(ErrorSameDestinationAndLocation);
            if (!playerSlotTown.Links.Any(t => t.Town.Name == Destination))
                throw new ArgumentException(ErrorDestinationNotLinked);
        }
    }
}