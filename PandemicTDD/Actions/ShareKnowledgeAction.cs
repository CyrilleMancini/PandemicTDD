using PandemicTDD;
using PandemicTDD.Actions;

namespace PandemicTDDTests.Running.Actions
{
    internal class ShareKnowledgeAction : ActionBase
    {
        private GameState gameState;
        private Player player;
        private string cardToShare;

        public ShareKnowledgeAction(GameState gameState, Player player, string cardToShare)
        {
            this.gameState = gameState;
            this.player = player;
            this.cardToShare = cardToShare;
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Try()
        {
            if (player.Town.Name != gameState.CurrentPlayer.Town.Name)
                throw new PlayerInDifferentTownsException();
        }
    }
}