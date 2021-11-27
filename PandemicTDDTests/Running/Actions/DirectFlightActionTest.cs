using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    [TestClass]
    public class DirectFlightActionTest : TestsBase
    {

        [TestMethod]
        public void DirectFlightToOwnedTownCard()
        {
            StartGame();

            PlayerTownCard DestiantionCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct);
            Players[0].PlayerCards.Add(DestiantionCard);

            ActionBase action = new DirectFlightAction(GameState, GameState.CurrentPlayer, DestiantionCard.Town.Name);
            GameState.DoAction(action);

            Assert.AreEqual(DestiantionCard.Town.Name, GameState.CurrentPlayer.Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
            Assert.AreEqual(DestiantionCard, GameState.Board.PlayerDiscardCardStack.Peek());
        }

        [TestMethod]
        public void DirectFlightToNotOwnedTownCard()
        {
            StartGame();
            GameState.CurrentPlayer.PlayerCards.Clear();

            ActionBase action = new DirectFlightAction(GameState, GameState.CurrentPlayer, TownsInitializer.Paris);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
                action.Execute();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
            Assert.AreEqual(TownsInitializer.Atlanta, GameState.CurrentPlayer.Town.Name);

        }

        [TestMethod]
        public void UsedCardIsOnTopOfPayerCard()
        {
            StartGame();

            PlayerTownCard DestinationCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct);
            Players[0].PlayerCards.Add(DestinationCard);

            ActionBase action = new DirectFlightAction(GameState, GameState.CurrentPlayer, DestinationCard.Town.Name);
            GameState.DoAction(action);


            Assert.AreEqual(DestinationCard, GameState.Board.PlayerDiscardCardStack.Peek(), "Player card shoud be in Discard stack");
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                DestinationCard = GameState.CurrentPlayer.GetCityPlayerCard<PlayerTownCard>(DestinationCard.Town.Name);
            }, "Player shouldn't have the used card anymore");

        }

    }
}
