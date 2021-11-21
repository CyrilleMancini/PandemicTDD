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
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly DiseaseColor diseaseColor;
        private readonly List<PlayerTownCard> cards;

        public DiscoverCureAction(GameState gameState, DiseaseColor color, List<PlayerTownCard> cards)
        {
            this.gameState = gameState;
            this.diseaseColor = color;
            this.cards = cards;
        }

        public override void Execute()
        {
            gameState.Board.GetCureSlots().DiscoverCure(diseaseColor);
            cards.ForEach(c => gameState.Board.PlayerDiscardCardStack.Push(c));
        }

        public override void Try()
        {
            if (!gameState.CurrentPlayer.Town.HasSearchStation)
                throw new CityWithoutControlCenterException(gameState.CurrentPlayer.Town.Name + " must have a search station.");

            if (cards.Count(c => c.Town.Color == diseaseColor) != 5)
                throw new NotEnoughCardToFindCureException($"5 {diseaseColor} cards required to discover a cure.");

        }
    }
}