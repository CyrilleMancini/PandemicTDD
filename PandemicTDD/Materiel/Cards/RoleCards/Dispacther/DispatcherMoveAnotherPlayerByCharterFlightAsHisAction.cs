using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDD.Materiel
{
    internal class DispatcherMoveAnotherPlayerByCharterFlightAsHisAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly Player MovedPlayer;
        private readonly string Destination;
        private TownSlot PlayerSlotTown;
        private TownSlot DestSlotTown;
        private PlayerTownCard OwnedCityCard;

        public DispatcherMoveAnotherPlayerByCharterFlightAsHisAction(GameState gameState, Player MovedPlayer, string destination)
        {
            this.gameState = gameState;
            this.MovedPlayer = MovedPlayer;
            Destination = destination;
        }

        public override void Execute()
        {

            MovedPlayer.Town = DestSlotTown.Town;
            gameState.Board.PlayerDiscardCardStack.Push(OwnedCityCard);

        }

        public override void Try()
        {
            if (MovedPlayer == gameState.CurrentPlayer)
                throw new InvalidPreconditionsException("The other player must be different than Current Player");

            PlayerSlotTown = gameState.Board.GetTownSlot(MovedPlayer.Town.Name);
            DestSlotTown = gameState.Board.GetTownSlot(Destination);

            if (PlayerSlotTown.Town.Name == Destination)
                throw new ArgumentException(DriveFerryAction.ErrorSameDestinationAndLocation);

            try
            {
                OwnedCityCard = gameState.CurrentPlayer.DiscardCardTown(PlayerSlotTown.Town.Name);
            }
            catch (NotOwnedCityPlayerCardException)
            {
                throw new NotOwnedCityPlayerCardException($"You must own origine {PlayerSlotTown.Town.Name} card from oother player origine to move him with a charter Flight");
            }

        }
    }
}