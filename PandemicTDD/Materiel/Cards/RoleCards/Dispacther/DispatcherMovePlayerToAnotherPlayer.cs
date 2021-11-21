using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;

namespace PandemicTDD.Materiel
{
    internal class DispatcherMovePlayerToAnotherPlayer : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private GameState GameState;
        private readonly Player OtherPlayer;
        private readonly string Destination;
        private ShuttleFlightAction IntermediateAction;

        public DispatcherMovePlayerToAnotherPlayer(GameState gameState, Player other, string Destination)
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
            if (OtherPlayer == GameState.CurrentPlayer)
                throw new InvalidPreconditionsException("The other must be different than Current Player");

            IntermediateAction = new ShuttleFlightAction(GameState, OtherPlayer, Destination);

            IntermediateAction.Try();

        }
    }
}