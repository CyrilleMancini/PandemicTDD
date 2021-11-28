using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDD.Actions
{
    internal class DirectFlightAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly Player MovedPlayer;
        private readonly string Destination;
        private TownSlot PlayerSlotTown;
        private TownSlot DestSlotTown;
        private PlayerTownCard OwnedCityCard;

        public DirectFlightAction(GameState gameState, Player MovedPlayer, string destination)
        {
            this.gameState = gameState;
            this.MovedPlayer = MovedPlayer;
            this.Destination = destination;
        }

        public override void Execute()
        {

            MovedPlayer.Town = DestSlotTown.Town;

            MovedPlayer.DiscardCardTown(Destination);
            gameState.Board.PlayerDiscardCardStack.Push(OwnedCityCard);

        }

        public override void Try()
        {
            PlayerSlotTown = gameState.Board.GetTownSlot(MovedPlayer.Town.Name);
            DestSlotTown = gameState.Board.GetTownSlot(Destination);

            if (PlayerSlotTown.Town.Name == Destination)
                throw new ArgumentException(DriveFerryAction.ErrorSameDestinationAndLocation);

            try
            {
                OwnedCityCard = MovedPlayer.GetCityPlayerCard<PlayerTownCard>(Destination);
            }
            catch (NotOwnedCityPlayerCardException)
            {
                throw new NotOwnedCityPlayerCardException($"You must own {Destination} card to do a Direct Flight");
            }
        }
    }
}