using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
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

            int requiredCardNumber = 5;

            if (gameState.CurrentPlayer.Role is ScientistRoleCard)
                requiredCardNumber = 4;

            if (cards.Count(c => c.Town.Color == diseaseColor) != requiredCardNumber)
                throw new NotEnoughCardToFindCureException($"{requiredCardNumber} {diseaseColor} cards required to discover a cure.");

        }
    }
}