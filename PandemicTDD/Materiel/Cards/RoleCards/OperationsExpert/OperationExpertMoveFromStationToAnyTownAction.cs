using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;

namespace PandemicTDDTests.Materiel
{

    /// <summary>
    /// Move to any town from Station and discard any card.
    /// </summary>
    public class OperationExpertMoveFromStationToAnyTownAction : ActionBase
    {
        private GameState gameState;
        private Town DestinationCity;
        private readonly string destination;
        private readonly PlayerTownCard discarded;

        public OperationExpertMoveFromStationToAnyTownAction(GameState gameState,string Destination, PlayerTownCard discarded)
        {
            this.gameState = gameState;
            destination = Destination;
            this.discarded = discarded;
        }

        public override void Execute()
        {
            gameState.CurrentPlayer.Town = DestinationCity;
        }

        public override void Try()
        {
            if (!gameState.CurrentPlayer.Town.HasSearchStation)
                throw new CityWithoutControlCenterException("The city must have a reseatch station to perform the action.");

            DestinationCity = gameState.Board.GetTown(destination);

        }
    }
}