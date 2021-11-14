using PandemicTDD.Materiel;
using System;
using System.Linq;

namespace PandemicTDD.Actions
{
    internal class DriveFerryAction : ActionBase
    {
        public const string ErrorDestinationNotLinked = "The Destination is not linked to Player Location.";

        public const string ErrorSameDestinationAndLocation = "Player Location and Destination are the same.";

        private readonly GameState gameState;

        private readonly string Destination;

        private TownSlot playerSlotTown;

        private TownSlot destSlotTown;

        public DriveFerryAction(GameState gameState, string destination)
        {
            this.gameState = gameState;
            Destination = destination;
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