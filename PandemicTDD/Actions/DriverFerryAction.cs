using PandemicTDD;
using PandemicTDD.Actions;

namespace PandemicTDDTests.Running.Actions
{
    internal class DriverFerryAction : ActionBase
    {
        private GameState gameState;
        private string Destination;

        public DriverFerryAction(GameState gameState, string destination)
        {
            this.gameState = gameState;
            this.Destination = destination;
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Try()
        {
            throw new System.NotImplementedException();
        }
    }
}