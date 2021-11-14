using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;

namespace PandemicTDDTests.Running.Actions
{
    internal class DiscoverCureAction : ActionBase
    {
        private GameState gameState;
        private DiseaseColor black;
        private List<PlayerTownCard> cards;

        public DiscoverCureAction(GameState gameState, DiseaseColor black, List<PlayerTownCard> cards)
        {
            this.gameState = gameState;
            this.black = black;
            this.cards = cards;
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Try()
        {
            if (gameState.Board.GetTownSlot(gameState.CurrentPlayer.Town).ControlDiseaseCenter == null)
                throw new CityWithoutControlCenterException(gameState.CurrentPlayer.Town.Name + " must have a search station.");

        }
    }
}