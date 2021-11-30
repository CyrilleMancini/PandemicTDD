using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDD.Actions
{
    public class CharterFlightAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

        private readonly GameState gameState;
        private readonly Player MovedPlayer;
        private readonly string Destination;
        private TownSlot PlayerSlotTown;
        private TownSlot DestSlotTown;
        private PlayerTownCard OwnedCityCard;

        public CharterFlightAction(GameState gameState, Player MovedPlayer, string destination)
        {
            this.gameState = gameState;
            this.MovedPlayer = MovedPlayer;
            this.Destination = destination;
        }

        public override void Execute()
        {

            MovedPlayer.Town = DestSlotTown.Town;
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
                OwnedCityCard = MovedPlayer.DiscardCardTown(PlayerSlotTown.Town.Name);
            }
            catch (NotOwnedCityPlayerCardException)
            {
                throw new NotOwnedCityPlayerCardException($"You must own origine {PlayerSlotTown.Town.Name} card to do a charter Flight");
            }

        }
    }
}