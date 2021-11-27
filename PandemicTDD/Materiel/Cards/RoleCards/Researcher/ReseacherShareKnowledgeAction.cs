using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDD.Materiel
{
    internal class ReseacherShareKnowledgeAction : ActionBase
    {

        public override bool ConsumeOneAction => true;

        private GameState gameState;
        private Player player;
        private string PlayerTownCardToShare;
        private PlayerTownCard Given;
        private PlayerTownCard Taken;

        public ReseacherShareKnowledgeAction(GameState gameState, Player player, string PlayerTownCardToShare)
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

            try
            {

                Given = gameState.CurrentPlayer.GetCityPlayerCard<PlayerTownCard>(PlayerTownCardToShare);
                if (gameState.CurrentPlayer.Role is not ResearcherRoleCard)
                {
                    throw new NotOwnedCityPlayerCardException("The card must come from The Researcher hands.");
                }
            }
            catch (Exception)
            {
                Taken = player.GetCityPlayerCard<PlayerTownCard>(PlayerTownCardToShare);
                if (player.Role is not ResearcherRoleCard)
                {
                    throw new NotOwnedCityPlayerCardException("The card must come from The Researcher hands.");
                }
            }

            if (Given == null && Taken == null)
                throw new NotOwnedCityPlayerCardException("Not any player have the card");
        }
    }
}