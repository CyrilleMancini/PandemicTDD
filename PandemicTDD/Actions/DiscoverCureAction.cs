using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    internal class DiscoverCureAction : ActionBase
    {
        private readonly GameState gameState;
        private readonly DiseaseColor diseaseColor;
        private readonly List<PlayerTownCard> cards;

        public DiscoverCureAction(GameState gameState, DiseaseColor black, List<PlayerTownCard> cards)
        {
            this.gameState = gameState;
            this.diseaseColor = black;
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

            if (cards.Count(c => c.Town.Color == diseaseColor) != 5)
                throw new NotEnoughCardToFindCureException($"5 {diseaseColor} cards required to discover a cure.");



        }
    }
}