using PandemicTDD.Materiel;
using System;
using System.Linq;

namespace PandemicTDD.Actions
{
    public class DriveFerryAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        public const string ErrorDestinationNotLinked = "The Destination is not linked to Player Location.";

        public const string ErrorSameDestinationAndLocation = "Player Location and Destination are the same.";

        private readonly GameState GameState;
        private readonly Player MovedPlayer;
        private readonly string Destination;
        private TownSlot playerSlotTown;
        private TownSlot destSlotTown;

        public DriveFerryAction(GameState gameState, Player movedPlayer, string destination)
        {
            GameState = gameState;
            MovedPlayer = movedPlayer;
            Destination = destination;
        }

        public override void Execute()
        {
            MovedPlayer.Town = destSlotTown.Town;
            GameState.Result($@"Player '{MovedPlayer.Name}' moved to {{destSlottown.Town.Name}}");
        }

        public override void Try()
        {
            playerSlotTown = GameState.Board.GetTownSlot(MovedPlayer.Town.Name);
            destSlotTown = GameState.Board.GetTownSlot(Destination);

            if (playerSlotTown.Town.Name == Destination)
                throw new ArgumentException(ErrorSameDestinationAndLocation);

            if (!playerSlotTown.Links.Any(t => t.Town.Name == Destination))
                throw new ArgumentException(ErrorDestinationNotLinked);
        }
    }
}