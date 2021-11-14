using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
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

            PlayerCard ParisPlayerCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Paris);
            Players[0].PlayerCards.Add(ParisPlayerCard);

            ActionBase action = new DirectFlightAction(GameState, TownsInitializer.Paris);
            GameState.DoAction(action);

            Assert.AreEqual(TownsInitializer.Paris, GameState.CurrentPlayer.Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void DirectFlightToNotOwnedTownCard()
        {
            StartGame();
            GameState.CurrentPlayer.PlayerCards.Clear();

            ActionBase action = new DirectFlightAction(GameState, TownsInitializer.Paris);
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

            PlayerCard ParisPlayerCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Paris);
            Players[0].PlayerCards.Add(ParisPlayerCard);

            ActionBase action = new DirectFlightAction(GameState, TownsInitializer.Paris);
            GameState.DoAction(action);


            Assert.AreEqual(ParisPlayerCard, GameState.Board.PlayerDiscardCardStack.Peek(), "Player card shoud be in Discard stack");
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                ParisPlayerCard = GameState.CurrentPlayer.GetCityPlayerCard(TownsInitializer.Paris);
            }, "Player shouldn't have the used card anymore");

        }

    }
}
