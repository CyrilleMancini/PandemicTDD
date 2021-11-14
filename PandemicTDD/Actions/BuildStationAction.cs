using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel.PlayerCards;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    internal class BuildStationAction : ActionBase
    {
        private GameState gameState;

        public BuildStationAction(GameState gameState )
        {
            this.gameState = gameState;
        }

        public override void Execute()
        {
            gameState.Board.GetTownSlot(gameState.CurrentPlayer.Town.Name).BuildStation();
        }

        public override void Try()
        {
            gameState.CurrentPlayer.GetCityPlayerCard(gameState.CurrentPlayer.Town.Name);

            

        }
    }
}