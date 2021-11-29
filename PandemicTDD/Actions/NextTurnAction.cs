namespace PandemicTDD.Actions
{
    public class NextTurnAction : ActionBase
    {
        private readonly GameState gameState;

        public NextTurnAction(GameState gameState)
        {
            this.gameState = gameState;
        }

        public override bool ConsumeOneAction => false;

        public override void Execute()
        {
            gameState.NextTurn();   
        }

        public override void Try()
        {
        }
    }
}