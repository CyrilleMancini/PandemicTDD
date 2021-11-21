using PandemicTDD;
using PandemicTDD.Actions;
using System;

namespace PandemicTDDTests.Materiel
{


    internal class OperationsExpertBuildStationAction : ActionBase
    {
        private GameState gameState;

        public OperationsExpertBuildStationAction(GameState gameState)
        {
            this.gameState = gameState;
        }

        public override void Execute()
        {
            gameState.Board.GetTownSlot(gameState.CurrentPlayer.Town).BuildStation();
        }

        public override void Try()
        {
            if (gameState.CurrentPlayer.Town.HasSearchStation)
            {
                String Message = $"Research Station already build in {gameState.CurrentPlayer.Town.Name}";
                gameState.Error(Message);
                throw new ArgumentException(Message);
            }

        }
    }
}