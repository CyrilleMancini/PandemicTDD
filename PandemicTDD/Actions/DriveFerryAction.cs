using PandemicTDD.Materiel;
using System;
using System.Linq;

namespace PandemicTDD.Actions
{
    internal class DriveFerryAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        public const string ErrorDestinationNotLinked = "The Destination is not linked to Player Location.";

        public const string ErrorSameDestinationAndLocation = "Player Location and Destination are the same.";

        private readonly GameState GameState;
        private readonly Player Player;
        private readonly string Destination;
        private TownSlot playerSlotTown;
        private TownSlot destSlotTown;

        public DriveFerryAction(GameState gameState,Player player, string destination)
        {
            GameState = gameState;
            Player = player;
            Destination = destination;
        }

        public override void Execute()
        {
            Player.Town = destSlotTown.Town;
            GameState.Result($@"Player '{Player.Name}' moved to {{destSlottown.Town.Name}}");
        }

        public override void Try()
        {
            playerSlotTown = GameState.Board.GetTownSlot(Player.Town.Name);
            destSlotTown = GameState.Board.GetTownSlot(Destination);

            if (playerSlotTown.Town.Name == Destination)
                throw new ArgumentException(ErrorSameDestinationAndLocation);
            
            if (!playerSlotTown.Links.Any(t => t.Town.Name == Destination))
                throw new ArgumentException(ErrorDestinationNotLinked);
        }
    }
}