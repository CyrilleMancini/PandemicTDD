using PandemicTDD;
using System;
using System.Collections.Generic;

namespace PandemicTDDApplication
{
    public class State003_ChooseLevel : BaseState
    {

        public State003_ChooseLevel(GameState gameState, IPandemicView view, IPandemicRessource Ressources) : 
            base(gameState, view, Ressources)
        {
        }

        public override void Instructions()
        {
            View.DisplayInstruction(Ressources.ChooseLevel);
        }


        public override RoleBaseState ChooseLevel(Difficulty level)
        {
            GameState
                .StartGame()
                .ChooseLevel(level);

            return GetStateFromCurrentPlayerRole();
        }
    }
}