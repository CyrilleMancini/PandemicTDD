using PandemicTDD;

namespace PandemicTDDTests.Running.Actions
{
    internal class DriverFerryCommand
    {
        private GameState gameState;
        private string chicago;

        public DriverFerryCommand(GameState gameState, string chicago)
        {
            this.gameState = gameState;
            this.chicago = chicago;
        }

        internal void Execute()
        {


        }
    }
}