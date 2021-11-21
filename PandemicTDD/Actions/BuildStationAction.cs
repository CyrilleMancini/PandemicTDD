using PandemicTDD.Materiel.PlayerCards;

namespace PandemicTDD.Actions
{
    internal class BuildStationAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private PlayerCard UsedCard;

        public BuildStationAction(GameState gameState)
        {
            this.gameState = gameState;
        }

        public override void Execute()
        {
            gameState.Board.GetTownSlot(gameState.CurrentPlayer.Town.Name).BuildStation();
            gameState.Board.PlayerDiscardCardStack.Push(UsedCard);

        }

        public override void Try()
        {
            UsedCard = gameState.CurrentPlayer.DiscardCardTown(gameState.CurrentPlayer.Town.Name);

        }
    }
}