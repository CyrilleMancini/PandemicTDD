using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class ContingencyPlannerRoleCard : RoleCard
    {
        public override List<Type> SpecialActions => specialActions;

        public List<Type> specialActions = new List<Type>()
        {
            typeof(ContingencyPlannerTakeEventCardFromDiscardAction),
            typeof(ContingencyPlannerPlaySpecialSlotAction)
        };

        public EventPlayerCard SpecialSlotEventCard { get; private set; } = null;

        internal void UseSpecialSlot()
        {
            SpecialSlotEventCard = null;
        }

        public ContingencyPlannerRoleCard(string name) : base(name)
        { }

        public void SetSpecialActionEventCard(EventPlayerCard card)
        {
            if (SpecialSlotEventCard != null)
                throw new Exception("Slot Already Used");

            SpecialSlotEventCard = card;
        }

        public void TrySpecialSlot()
        {
            if (SpecialSlotEventCard == null)
                throw new InvalidPreconditionsException($"You must have an Event card retrieved from the Discard Stack");

            SpecialSlotEventCard.EventAction.Try();
        }

        public void ExecuteSpecialSlot()
        {
            SpecialSlotEventCard.EventAction.Execute();
        }

    }
}