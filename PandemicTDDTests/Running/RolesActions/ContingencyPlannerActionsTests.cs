using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;

namespace PandemicTDDTests.Materiel
{

    [TestClass()]
    public partial class ContingencyPlannerActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new ContingencyPlannerRoleCard("Planificateur d'urgence");
            GameState.Board.PlayerDiscardCardStack.Push(new ResilientPopulationEventCard(ressource));
            GameState.Board.PlayerDiscardCardStack.Push(new AirLiftEventCard(ressource));
            GameState.Board.PlayerDiscardCardStack.Push(new PublicSubventionEventCard(ressource));
            GameState.Board.PlayerDiscardCardStack.Push(new ResilientPopulationEventCard(ressource));
        }

        [TestMethod()]
        public void TakenCardMustBeInTheDiscardStack()
        {
            EventPlayerCard TakenFromDiscard = new CalmNigthEventCard(ressource);

            ActionBase action = new ContingencyPlannerTakeEventCardFromDiscardAction(GameState, TakenFromDiscard);
            Assert.ThrowsException<CardNotInDiscardStackException>(() =>
            {
                action.Try();
            });
        }

        [TestMethod()]
        public void TakenCardIsInSpecialRoleCardSlot()
        {
            EventPlayerCard TakenFromDiscard = new AirLiftEventCard(ressource);
            ActionBase action = new ContingencyPlannerTakeEventCardFromDiscardAction(GameState, TakenFromDiscard);
            GameState.DoAction(action);

            Assert.AreEqual(TakenFromDiscard.GetType(), ((ContingencyPlannerRoleCard)Players[0].Role).SpecialSlotEventCard.GetType());
        }


        [TestMethod()]
        public void PlannerMustHaveARetreivedCardFromStack()
        {
            ActionBase action = new ContingencyPlannerPlaySpecialSlotAction(GameState);

            Assert.ThrowsException<InvalidPreconditionsException>(() =>
            {
                action.Try();
            });

        }


        [TestMethod()]
        public void TestFakeEventCard()
        {
            FakeEventCard card = new FakeEventCard();
            card.EventAction.Try();
            Assert.IsTrue(((FakeEventCardAction)card.EventAction).Tried);
        }

        [TestMethod()]
        public void PlaysTheRetreivedCardFromStack()
        {
            FakeEventCard TakenFromDiscard = new FakeEventCard();
            GameState.Board.PlayerDiscardCardStack.Push(TakenFromDiscard);
            ActionBase action = new ContingencyPlannerTakeEventCardFromDiscardAction(GameState, TakenFromDiscard);
            GameState.DoAction(action);

            ContingencyPlannerPlaySpecialSlotAction action2 = new(GameState);
            action2.Try();
            action2.Execute();

            Assert.IsTrue(((FakeEventCardAction)TakenFromDiscard.EventAction).Tried);
            Assert.IsTrue(((FakeEventCardAction)TakenFromDiscard.EventAction).Played);
            Assert.IsNull(action2.Role.SpecialSlotEventCard);
        }

    }
}