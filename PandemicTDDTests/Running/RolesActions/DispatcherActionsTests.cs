using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public partial class DispatcherActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new DispatcherRoleCard("Répartiteur");
            GameState.Board.PlayerDiscardCardStack.Push(new ResilientPopulationEventCard());
            GameState.Board.PlayerDiscardCardStack.Push(new AirLiftEventCard());
            GameState.Board.PlayerDiscardCardStack.Push(new PublicSubventionEventCard());
            GameState.Board.PlayerDiscardCardStack.Push(new ResilientPopulationEventCard());
        }
    }
}