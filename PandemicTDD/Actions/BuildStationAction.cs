namespace PandemicTDD.Actions
{
    internal class BuildStationAction : ActionBase
    {
        private readonly GameState gameState;

        public BuildStationAction(GameState gameState)
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