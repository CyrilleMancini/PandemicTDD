using Microsoft.AspNetCore.Components;
using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDDApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandemicClientBlazor.Pages
{
    public partial class Board : IPandemicView
    {

        public bool Failed { get; set; } = false;
        public bool Victory { get; set; } = false;

        IDebuggableUI DebugPanel;

        [Inject]
        IPandemicRessource ressource { get; set; }

        [Inject]
        GameState GameState { get; set; }

        Instructions InstructionsPanel;

        PlayerActions playerActions;

        SelectDestination SelectDestination;

        RoleBaseState roleState;
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
                roleState = baseState.ChooseLevel(Difficulty.Standard);

                roleState.Instructions();

                GameState.OnFailure += GameState_OnFailure;
                GameState.OnVictory += GameState_OnVictory;
            }
            base.OnAfterRender(firstRender);
        }

        private void Play()
        {
            roleState = roleState.WaitAction();
            roleState.Instructions();

        }

        private void GameState_OnFailure(object sender, string e)
        {

        }

        private void GameState_OnVictory(object sender, string e)
        {
            throw new NotImplementedException();
        }

        public void AddPlayerAction(string ActionName, Action action)
        {
            playerActions.AddAction(ActionName, action);
        }

        public void AskAction()
        {
            playerActions.Visible = true;
        }

        public string AskDestinationAmong(Town[] Destinations) {
             
            return  SelectDestination.SetDestination(Destinations);
        }

        public DiseaseColor AskDiseaseColor() =>            throw new NotImplementedException();

        public void DisplayActions()
        {
            Console.WriteLine("DisplayActions");
            playerActions.Visible = true;
        }

        public void DisplayBoard(PandemicTDD.Materiel.Board board) => playerActions.Clear();

        public void DisplayInstruction(string instruction)
        {
            InstructionsPanel.Add(instruction);
            StateHasChanged();
        }

        public void DisplayLocation(Town town) { }

        Player CurrentPlayer;
        public void DisplayPlayer(Player current)
        {
            Console.WriteLine("DisplayPlayer");
            CurrentPlayer = current;
        }

    }
}
