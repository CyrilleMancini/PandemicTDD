﻿using PandemicTDD;
using System;

namespace PandemicTDDApplication
{
    internal class State020_PlayContingencyPlannerRole : RoleBaseState
    {
        public State020_PlayContingencyPlannerRole(GameState gameState, IPandemicView view, IPandemicRessource Ressources) : base(gameState, view, Ressources)
        {
        }

        protected override void AddSpecialActions()
        {
            View.AddPlayerAction(Ressources.Action_PlayCardFromSpecialSlot, ActionPlaySpecialSlotCard);
        }

        private void ActionPlaySpecialSlotCard()
        {
            throw new NotImplementedException();
        }
    }
}