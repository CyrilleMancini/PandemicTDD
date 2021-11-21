using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class ContingencyPlannerActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new ContingencyPlannerRoleCard("Planificateur d'urgence");
            GameState.Board.PlayerDiscardCardStack.Push(new ResilientPopulationEventCard());
            GameState.Board.PlayerDiscardCardStack.Push(new AirLiftEventCard());
            GameState.Board.PlayerDiscardCardStack.Push(new PublicSubventionEventCard());
            GameState.Board.PlayerDiscardCardStack.Push(new ResilientPopulationEventCard());
        }

        [TestMethod()]
        public void TakenCardMustBeInTheDiscardStack()
        {
            EventPlayerCard TakenFromDiscard = new CalmNigthEventCard();

            ActionBase action = new ContingencyPlannerTakeEventCardFromDiscardAction(GameState, TakenFromDiscard);
            Assert.ThrowsException<CardNotInDiscardStackException>(() =>
            {
                action.Try();
            });
        }

        [TestMethod()]
        public void TakenCardIsInSpecialRoleCardSlot()
        {
            EventPlayerCard TakenFromDiscard = new AirLiftEventCard();
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
        public void PlaysTheRetreivedCardFromStack()
        {
            FakeEventCard TakenFromDiscard = new FakeEventCard();
            GameState.Board.PlayerDiscardCardStack.Push(TakenFromDiscard);
            ActionBase action = new ContingencyPlannerTakeEventCardFromDiscardAction(GameState, TakenFromDiscard);
            GameState.DoAction(action);

            ContingencyPlannerPlaySpecialSlotAction action2 = new(GameState);
            action2.Try();
            action2.Execute();

            Assert.IsTrue(((FakeEventCardAction)action2.Role.SpecialSlotEventCard.EventAction).Tried);
            Assert.IsTrue(((FakeEventCardAction)TakenFromDiscard.EventAction).Played);

        }

        public class FakeEventCard : EventPlayerCard
        {
            public override ActionBase EventAction => new FakeEventCardAction();
        }

        public class FakeEventCardAction : ActionBase
        {
            public override bool ConsumeOneAction => true;

            public bool Played { get; set; } = false;

            public bool Tried { get; set; } = false;

            public override void Execute()
            {
                Played = true;
            }

            public override void Try()
            {
                Tried = true;
            }
        }


    }
}