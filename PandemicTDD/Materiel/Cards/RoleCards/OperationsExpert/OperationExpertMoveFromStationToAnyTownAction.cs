using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
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
        public override bool ConsumeOneAction => false;

        private GameState gameState;
        private Town DestinationCity;
        private readonly string Destination;
        private readonly PlayerTownCard Discarded;

        public OperationExpertMoveFromStationToAnyTownAction(GameState gameState, string Destination, PlayerTownCard discarded)
        {
            this.gameState = gameState;
            this.Destination = Destination;
            this.Discarded = discarded;
        }

        public override void Execute()
        {
            gameState.CurrentPlayer.Town = DestinationCity;
            gameState.CurrentPlayer.DiscardCardTown(Discarded.Town.Name);
            gameState.Board.PlayerDiscardCardStack.Push(Discarded);
        }

        public override void Try()
        {
            if (!gameState.CurrentPlayer.Town.HasSearchStation)
                throw new CityWithoutControlCenterException("The city must have a reseatch station to perform the action.");

            if (gameState.ActionsTurnHistory.AlreadyPlayed<OperationExpertMoveFromStationToAnyTownAction>())
                throw new ActionCanBeDoneOnlyOncePerTurn("Moving from station to any town can only be one one per turn.");

            DestinationCity = gameState.Board.GetTown(Destination);

        }
    }
}