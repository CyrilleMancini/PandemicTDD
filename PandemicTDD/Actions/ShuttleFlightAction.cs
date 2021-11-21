using PandemicTDD.Actions.Exceptions;

namespace PandemicTDD.Actions
{
    internal class ShuttleFlightAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly string Destination;

        public ShuttleFlightAction(GameState gameState, string destination)
        {
            this.gameState = gameState;
            Destination = destination;
        }

        public override void Execute()
        {
            gameState.CurrentPlayer.Town = gameState.Board.GetTownSlot(Destination).Town;

        }

        public override void Try()
        {
            if (gameState.CurrentPlayer.Town.HasSearchStation == false)
                throw new CityWithoutControlCenterException("Origin City doesn't have CDC");

            if (gameState.Board.GetTownSlot(Destination).HasSearchStation == false)
                throw new CityWithoutControlCenterException("Destination City doesn't have CDC");

        }
    }
}