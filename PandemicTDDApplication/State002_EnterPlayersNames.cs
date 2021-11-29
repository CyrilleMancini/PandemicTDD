using PandemicTDD;
using PandemicTDDApplication.Exceptions;
using System.Collections.Generic;

namespace PandemicTDDApplication
{
    public class State002_EnterPlayersNames : BaseState
    {
        private readonly int playerNumber;

        private int currentPlayer = 1;

        List<Player> Players = new List<Player>();

        public State002_EnterPlayersNames(GameState gameState, IPandemicView view, IPandemicRessource Ressources, int playerNumber) : base(gameState, view, Ressources)
        {
            this.playerNumber = playerNumber;
        }

        public override void Instructions()
        {
            View.DisplayInstruction(Ressources.EnterPlayerName(currentPlayer ));
        }

        public override BaseState EnterPlayerName(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
                throw new InvalidInputException(Ressources.InvalidPlayerName(playerName));

            Players.Add(new Player() { Name = playerName });

            currentPlayer++;
            if (currentPlayer <= playerNumber)
                return this;
            else
            {
                GameState.SetPlayers(Players);
                return new State003_ChooseLevel(GameState, View, Ressources);
            }
        }
    }
}