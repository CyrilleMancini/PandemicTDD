using PandemicTDD;
using PandemicTDD.Actions;

namespace PandemicTDDTests.Running.Actions
{
    internal class ShuttleFlightAction : ActionBase
    {
        private GameState gameState;
        private string Destination;

        public ShuttleFlightAction(GameState gameState, string destination)
        {
            this.gameState = gameState;
            this.Destination = destination;
        }

        public override void Execute()
        {
            gameState.CurrentPlayer.Town = gameState.Board.GetTownSlot(Destination).Town;

        }

        public override void Try()
        {
            if (gameState.Board.GetTownSlot(gameState.CurrentPlayer.Town.Name).ControlDiseaseCenter == null)
                throw new CityWithoutControlCenterException("Origin City doesn't have CDC");

            if (gameState.Board.GetTownSlot(Destination).ControlDiseaseCenter == null)
                throw new CityWithoutControlCenterException("Destination City doesn't have CDC");

        }
    }
}