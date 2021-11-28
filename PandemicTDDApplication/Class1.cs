using PandemicTDD;
using System;

namespace PandemicTDDApplication
{

    /*
     2. Choix Nb Joueur 
     3. Nom des joueurs
     1. Initialisation
     3. 
    */
    public class Class1
    {
    }


    public abstract class BaseState
    {
        protected GameState GameState { get; set; }

        protected BaseState(GameState gameState)
        {
            GameState = gameState;
        }
    }

    public class State001_NumberPlayers : BaseState
    {
        public State001_NumberPlayers(GameState gameState) : base(gameState)
        {
        }



    }


}
