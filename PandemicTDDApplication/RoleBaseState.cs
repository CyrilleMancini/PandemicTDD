using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDD.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;

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
            View.DisplayBoard(GameState.Board);
            View.DisplayPlayer(GameState.CurrentPlayer);
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
            View.AskDiseaseColor((color) =>
            {
                GameState.DoAction(new TreatDiseaseAction(GameState, color));
            });
        }

        private void ActionShareKnowledge()
        {
            throw new NotImplementedException();
        }

        private void ActionDiscoverCure()
        {
            try
            {
                View.AskDiseaseColor((color) =>
                {
                    List<PlayerTownCard> cards = GameState.CurrentPlayer
                        .PlayerCards
                        .Where(c => c is PlayerTownCard tc && tc.Town.Color == color)
                        .Select(c => (PlayerTownCard)c)
                        .ToList();
                    GameState.DoAction(new DiscoverCureAction(GameState, color, cards));
                });
            }
            catch
            {

            }
        }

        private void ActionShuttleFlight()
        {
            Town[] towns = GameState.Board.GetTownsWithResearchCenter();
            View.AskDestinationAmong(towns, (dest) =>
            {
                GameState.DoAction(new ShuttleFlightAction(GameState, GameState.CurrentPlayer, dest));
            });
        }

        private void ActionChargerFlight()
        {
            Town[] CharterDestinations = GameState.Board.GetTownSlots().Select(ts => ts.Town).ToArray();
            View.AskDestinationAmong(CharterDestinations, (dest) =>
            {
                GameState.DoAction(new DirectFlightAction(GameState, GameState.CurrentPlayer, dest));
            });
        }

        private void ActionDirectFlight()
        {
            PlayerTownCard[] Cards = GameState.CurrentPlayer.GetCityCards();
            Town[] Destinations = Cards.Select(c => c.Town).ToArray();
            View.AskDestinationAmong(Destinations, (dest) =>
            {
                GameState.DoAction(new DirectFlightAction(GameState, GameState.CurrentPlayer, dest));
            });
        }

        private void ActionDriverFerry()
        {
            TownSlot slot = GameState.GetCurrentPlayerTownSlot();
            View.AskDestinationAmong(slot.Links.Select(ts => ts.Town).ToArray(), (dest) =>
            {
                GameState.DoAction(new DriveFerryAction(GameState, GameState.CurrentPlayer, dest));
            });

        }



    }
}