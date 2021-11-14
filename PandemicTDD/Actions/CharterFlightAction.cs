﻿using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDD.Actions
{
    internal class CharterFlightAction : ActionBase
    {
        private GameState gameState;
        private string Destination;
        private TownSlot PlayerSlotTown;
        private TownSlot DestSlotTown;
        private PlayerTownCard OwnedCityCard;

        public CharterFlightAction(GameState gameState, string destination)
        {
            this.gameState = gameState;
            this.Destination = destination;
        }

        public override void Execute()
        {

            gameState.CurrentPlayer.Town = DestSlotTown.Town;

            gameState.CurrentPlayer.PlayerCards.Remove(OwnedCityCard);
            gameState.Board.PlayerDiscardCardStack.Push(OwnedCityCard);

        }

        public override void Try()
        {
            PlayerSlotTown = gameState.Board.GetTownSlot(gameState.CurrentPlayer.Town.Name);
            DestSlotTown = gameState.Board.GetTownSlot(Destination);

            if (PlayerSlotTown.Town.Name == Destination)
                throw new ArgumentException(DriveFerryAction.ErrorSameDestinationAndLocation);

            try
            {
                OwnedCityCard = (PlayerTownCard)gameState.CurrentPlayer.GetCityPlayerCard(PlayerSlotTown.Town.Name);
            }
            catch (NotOwnedCityPlayerCardException)
            {
                throw new NotOwnedCityPlayerCardException($"You must own origine {PlayerSlotTown.Town.Name} card to do a charter Flight");
            }

        }
    }
}