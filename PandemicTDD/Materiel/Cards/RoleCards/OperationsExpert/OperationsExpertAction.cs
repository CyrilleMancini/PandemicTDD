using PandemicTDD;
using PandemicTDD.Actions;
using System;

namespace PandemicTDDTests.Materiel
{
    internal class OperationsExpertAction : ActionBase
    {
        private GameState gameState;

        public OperationsExpertAction(GameState gameState)
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
                throw new ArgumentException($"Research Station already build in {gameState.CurrentPlayer.Town.Name}");
            }

        }
    }
}