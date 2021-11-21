using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{

    internal class ContingencyPlannerTakeEventCardFromDiscardAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private GameState GameState;
        private readonly EventPlayerCard TakenFromDiscard;

        public ContingencyPlannerTakeEventCardFromDiscardAction(GameState gameState, EventPlayerCard takenFromDiscard)
        {
            GameState = gameState;
            TakenFromDiscard = takenFromDiscard;
        }

        public override void Execute()
        {
            Stack<PlayerCard> TmpStack = new Stack<PlayerCard>();
            while (GameState.Board.PlayerDiscardCardStack.TryPeek(out PlayerCard card))
            {
                if (!card.GetType().Equals(TakenFromDiscard.GetType()))
                {
                    TmpStack.Push(GameState.Board.PlayerDiscardCardStack.Pop());
                }
                else if (card is EventPlayerCard eCard)
                {
                    GameState.Board.PlayerDiscardCardStack.Pop();
                    ((ContingencyPlannerRoleCard)GameState.CurrentPlayer.Role).SetSpecialActionEventCard((EventPlayerCard)card);
                    break;
                }
            }

            // Restack card
            while (TmpStack.Count != 0)
            {
                GameState.Board.PlayerDiscardCardStack.Push(TmpStack.Pop());
            }

        }

        public override void Try()
        {
            if (GameState.CurrentPlayer.Role is not ContingencyPlannerRoleCard)
                throw new ArgumentException($"This action can only be bone by a Contingency Planner");

            if (!GameState.Board.PlayerDiscardCardStack.Any(c => c.GetType().Equals(TakenFromDiscard.GetType())))
                throw new CardNotInDiscardStackException($"The taken card is not in the discard stack.");
        }
    }
}