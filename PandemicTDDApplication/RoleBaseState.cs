using PandemicTDD;
using PandemicTDD.Actions;
using System;

namespace PandemicTDDApplication
{
    public abstract class RoleBaseState : BaseState
    {
        protected RoleBaseState(GameState gameState, IPandemicView view, IPandemicRessource Ressources)
            : base(gameState, view, Ressources)
        {
        }

        public override void Instructions()
        {
            DisplayPlayerInfos();
            AddStandardActions();
            //AddSpecialActions();
            View.DisplayActions();
        }

        public RoleBaseState WaitAction()
        {
            View.AskAction();
            return GetStateFromCurrentPlayerRole();
        }

        protected abstract void AddSpecialActions();

        protected void DisplayPlayerInfos()
        {
            View.DisplayInstruction(Ressources.PlayerYourTurn(GameState.CurrentPlayer));
            View.DisplayInstruction(Ressources.ActionsRemains(GameState.ActionsRemaining));
            View.DisplayLocation(GameState.CurrentPlayer.Town);
        }

        protected void AddStandardActions()
        {
            View.AddPlayerAction(Ressources.Action_DriveFerry, ActionDriverFerry);
            View.AddPlayerAction(Ressources.Action_DirectFlight, ActionDirectFlight);
            View.AddPlayerAction(Ressources.Action_CharterFlight, ActionChargerFlight);
            View.AddPlayerAction(Ressources.Action_ShuttleFlight, ActionShuttleFlight);
            View.AddPlayerAction(Ressources.Action_DiscoverCure, ActionDiscoverCure);
            View.AddPlayerAction(Ressources.Action_ShareKnowledge, ActionShareKnowledge);
            View.AddPlayerAction(Ressources.Action_TreatDisease, ActionTreatDisease);
            View.AddPlayerAction(Ressources.Action_BuildStation, ActionBuildStation);
            View.AddPlayerAction(Ressources.Action_NextTurn, ActionNextTurn);
        }

        private void ActionNextTurn()
        {
            GameState.DoAction(new NextTurnAction(GameState));
        }

        private void ActionBuildStation()
        {
            GameState.DoAction(new BuildStationAction(GameState, GameState.CurrentPlayer));
        }

        private void ActionTreatDisease()
        {
            throw new NotImplementedException();
        }

        private void ActionShareKnowledge()
        {
            throw new NotImplementedException();
        }

        private void ActionDiscoverCure()
        {
            throw new NotImplementedException();
        }

        private void ActionShuttleFlight()
        {
            throw new NotImplementedException();
        }

        private void ActionChargerFlight()
        {
            throw new NotImplementedException();
        }

        private void ActionDirectFlight()
        {
            throw new NotImplementedException();
        }

        private void ActionDriverFerry()
        {
            string dest = View.AskDestinationAmong(new[] { "Chicago", "New-York" });
            GameState.DoAction(new DriveFerryAction(GameState, GameState.CurrentPlayer, dest));
        }
    }
}