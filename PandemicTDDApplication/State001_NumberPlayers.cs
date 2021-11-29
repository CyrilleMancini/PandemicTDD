using PandemicTDD;
using PandemicTDDApplication.Exceptions;

namespace PandemicTDDApplication
{
    public class State001_NumberPlayers : BaseState
    {

        public State001_NumberPlayers(GameState gameState, IPandemicView view, IPandemicRessource ressources)
            : base(gameState, view, ressources)
        { }

        public override void Instructions()
        {
            View.DisplayInstruction(Ressources.EnterPlayerNumber);
        }


        public BaseState SetNumberPlayer(int nbPlayers)
        {
            if (nbPlayers < 2 || nbPlayers > 4)
                throw new InvalidInputException(Ressources.InvalidPlayersNumber);

            return new State002_EnterPlayersNames(GameState, View, Ressources, nbPlayers);

        }
    }
}
