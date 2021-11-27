using PandemicTDD.Materiel.PlayerCards;

namespace PandemicTDD.Actions
{
    internal class BuildStationAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly Player player;
        private PlayerCard UsedCard;

        public BuildStationAction(GameState gameState,Player player)
        {
            this.gameState = gameState;
            this.player = player;
        }

        public override void Execute()
        {
            gameState.Board.GetTownSlot(player.Town.Name).BuildStation();
            gameState.Board.PlayerDiscardCardStack.Push(UsedCard);
        }

        public override void Try()
        {
            UsedCard = player.DiscardCardTown(player.Town.Name);

        }
    }
}