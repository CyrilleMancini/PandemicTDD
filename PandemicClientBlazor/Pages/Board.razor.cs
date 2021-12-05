using Microsoft.AspNetCore.Components;
using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDD.Ressources;
using PandemicTDDApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandemicClientBlazor.Pages
{
    public partial class Board : IPandemicView, IObserveGameState
    {

        public bool Failed { get; set; } = false;
        public bool Victory { get; set; } = false;

        IDebuggableUI DebugPanel;

        [Inject]
        IPandemicRessource ressource { get; set; }

        [Inject]
        GameState GameState { get; set; }

        Instructions InstructionsPanelComponent;

        PlayerActions playerActionsComponent;

        SelectDestination SelectDestinationComponent;

        RoleBaseState roleStateComponent;

        Errors ErrorsComponent;

        protected override void OnInitialized()
        {
            GameState.RegisterObserver(this);
            base.OnInitialized();
        }
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                BaseState baseState = new State001_NumberPlayers(GameState, this, ressource);
                baseState.Instructions();
                baseState = baseState.SetNumberPlayer(2);

                baseState.Instructions();
                baseState = baseState.EnterPlayerName("titi");

                baseState.Instructions();
                baseState = baseState.EnterPlayerName("toto");

                baseState.Instructions();
                roleStateComponent = baseState.ChooseLevel(Difficulty.Standard);

                roleStateComponent.Instructions();

                GameState.OnFailure += GameState_OnFailure;
                GameState.OnVictory += GameState_OnVictory;
            }
            base.OnAfterRender(firstRender);
        }

        private void Play()
        {
            DebugPanel.Log("Call:Play");
            roleStateComponent = roleStateComponent.WaitAction();
            roleStateComponent.Instructions();

        }

        private void GameState_OnFailure(object sender, string e)
        {
            DebugPanel.Log("Call:OnFailure");

        }

        private void GameState_OnVictory(object sender, string e)
        {
            DebugPanel.Log("Call:OnVictory");
            throw new NotImplementedException();
        }

        public void AddPlayerAction(string ActionName, Action action)
        {
            DebugPanel.Log($"Call:AddPlayerAction:{ActionName}");
            playerActionsComponent.AddAction(ActionName, action);
        }

        public void AskAction()
        {
            DebugPanel.Log($"Call:AskAction:");
            playerActionsComponent.Visible = true;
        }

        #region Destination
        public void AskDestinationAmong(Town[] Destinations, IWaitDestinationDelegate CallerAction)
        {
            DebugPanel.Log($"Call:AskDestinationAmong");
            SelectDestinationComponent.SetDestinations(Destinations);
            CurrentCallerAction = CallerAction;
        }

        IWaitDestinationDelegate CurrentCallerAction;

        void DestinationSelected(string SelectedDestination)
        {
            DebugPanel.Log($"Call:Destination Selected {SelectedDestination}");
            if (CurrentCallerAction == null) return;
            CurrentCallerAction(SelectedDestination);
        }
        #endregion

        #region Color
        public void AskDiseaseColor(IWaitForColor CallerAction)
        {
            DebugPanel.Log($"Call:AskDiseaseColor");
            CallerAction(DiseaseColor.Blue);
        }

        #endregion
        public void DisplayActions()
        {
            DebugPanel.Log($"Call:DisplayAction");
            playerActionsComponent.Visible = true;
        }

        public void DisplayBoard(PandemicTDD.Materiel.Board board)
        {
            DebugPanel.Log($"Call:DisplayBoard");
            playerActionsComponent.Clear();
        }

        public void DisplayInstruction(string instruction)
        {
            DebugPanel.Log($"Call:Instruction");
            InstructionsPanelComponent.Add(instruction);
            StateHasChanged();
        }

        public void DisplayLocation(Town town)
        {
            DebugPanel.Log($"Call:DisplayLocation");
        }

        Player CurrentPlayer;
        public void DisplayPlayer(Player current)
        {
            DebugPanel.Log($"Call:DisplayPlayer");
            CurrentPlayer = current;
        }

        public void Error(string ErrorMessage)
        {
            InstructionsPanelComponent.Add(ErrorMessage);
            ErrorsComponent.SetError(ErrorMessage);
        }

        public void Action(string ActionMessage)
        {
            InstructionsPanelComponent.Add(ActionMessage);
        }

        public void Result(string message)
        {
            InstructionsPanelComponent.Add(message);
        }
    }
}
