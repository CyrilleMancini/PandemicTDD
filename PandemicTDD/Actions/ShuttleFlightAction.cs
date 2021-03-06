using PandemicTDD.Actions.Exceptions;

namespace PandemicTDD.Actions
{
    public class ShuttleFlightAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly Player MovedPlayer;
        private readonly string Destination;

        public ShuttleFlightAction(GameState gameState, Player movedPlayer, string destination)
        {
            this.gameState = gameState;
            MovedPlayer = movedPlayer;
            Destination = destination;
        }

        public override void Execute()
        {
            MovedPlayer.Town = gameState.Board.GetTownSlot(Destination).Town;

        }

        public override void Try()
        {
            if (MovedPlayer.Town.HasSearchStation == false)
                throw new CityWithoutControlCenterException("Origin City doesn't have CDC");

            if (gameState.Board.GetTownSlot(Destination).HasSearchStation == false)
                throw new CityWithoutControlCenterException("Destination City doesn't have CDC");
        }
    }
}