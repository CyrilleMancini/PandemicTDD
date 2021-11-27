using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDD.Materiel
{
    internal class DispatcherMoveAnotherPlayerByDirectFlightAsHisAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly Player MovedPlayer;
        private readonly string Destination;
        private TownSlot PlayerSlotTown;
        private TownSlot DestSlotTown;
        private PlayerTownCard OwnedCityCard;

        public DispatcherMoveAnotherPlayerByDirectFlightAsHisAction(GameState gameState, Player MovedPlayer, string destination)
        {
            this.gameState = gameState;
            this.MovedPlayer = MovedPlayer;
            Destination = destination;
        }

        public override void Execute()
        {

            MovedPlayer.Town = DestSlotTown.Town;

            gameState.CurrentPlayer.DiscardCardTown(Destination);
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
                OwnedCityCard = gameState.CurrentPlayer.GetCityPlayerCard<PlayerTownCard>(Destination);
            }
            catch (NotOwnedCityPlayerCardException)
            {
                throw new NotOwnedCityPlayerCardException($"You must own {Destination} card to move an other player with Direct Flight");
            }
        }
    }
}