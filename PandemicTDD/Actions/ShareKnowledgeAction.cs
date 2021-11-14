using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDD.Actions
{
    internal class ShareKnowledgeAction : ActionBase
    {
        private readonly GameState gameState;

        private readonly Player player;

        private readonly string PlayerTownCardToShare;

        private PlayerTownCard Given;

        private PlayerTownCard Taken;

        public ShareKnowledgeAction(GameState gameState, Player player, string PlayerTownCardToShare)
        {
            this.gameState = gameState;
            this.player = player;
            this.PlayerTownCardToShare = PlayerTownCardToShare;
        }

        public override void Execute()
        {
            if (Given != null)
            {
                player.PlayerCards.Add(Given);
                gameState.CurrentPlayer.PlayerCards.Remove(Given);
            }
            if (Taken != null)
            {
                gameState.CurrentPlayer.PlayerCards.Add(Taken);
                player.PlayerCards.Remove(Taken);
            }
        }

        public override void Try()
        {
            if (player.Town.Name != gameState.CurrentPlayer.Town.Name)
                throw new PlayerInDifferentTownsException();

            if (gameState.CurrentPlayer.Town.Name != PlayerTownCardToShare)
                throw new PlayersMustBeInTheShareTownCardException();

            try
            {
                Given = (PlayerTownCard)gameState.CurrentPlayer.GetCityPlayerCard(PlayerTownCardToShare);

            }
            catch (Exception)
            {
                Taken = (PlayerTownCard)player.GetCityPlayerCard(PlayerTownCardToShare);
            }

            if (Given == null && Taken == null)
                throw new NotOwnedCityPlayerCardException();

        }
    }
}