using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;

namespace PandemicTDD.Materiel
{
    internal class DispatcherMoveAnotherPlayerByDriverFerryAsHisAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private GameState GameState;
        private readonly Player OtherPlayer;
        private readonly string Destination;
        private DriveFerryAction IntermediateAction;

        public DispatcherMoveAnotherPlayerByDriverFerryAsHisAction(GameState gameState, Player other, string Destination)
        {
            GameState = gameState;
            OtherPlayer = other;
            this.Destination = Destination;
        }

        public override void Execute()
        {
            IntermediateAction.Execute();
        }

        public override void Try()
        {
            if(GameState.CurrentPlayer.Role is not DispatcherRoleCard)
                throw new InvalidPreconditionsException("This Card can only be played by The Dispatcher");


            if (OtherPlayer == GameState.CurrentPlayer)
                throw new InvalidPreconditionsException("The other must be different than Current Player");

            IntermediateAction = new DriveFerryAction(GameState, OtherPlayer, Destination);

            IntermediateAction.Try();

        }
    }
}