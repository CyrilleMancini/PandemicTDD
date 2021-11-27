using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;

namespace PandemicTDD.Materiel
{
    internal class DispatcherMovePlayerToAnotherPlayer : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private GameState GameState;
        private readonly Player OtherPlayer;
        private readonly Player DestinationPlayer;
 
        public DispatcherMovePlayerToAnotherPlayer(GameState gameState, Player PlayerFrom, Player DestinationPlayer)
        {
            GameState = gameState;
            OtherPlayer = PlayerFrom;
            this.DestinationPlayer = DestinationPlayer;
        }

        public override void Execute()
        {
            OtherPlayer.Town = DestinationPlayer.Town;

        }

        public override void Try()
        {
            if (OtherPlayer == DestinationPlayer)
                throw new InvalidPreconditionsException("Origine and destination Players must be different.");




        }
    }
}