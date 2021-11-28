using CommonTestsTools;
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
    public class BuildResearchStationTests : TestsBase
    {

        [TestMethod]
        public void BuildStationOnOwnedTownCard()
        {
            StartGame();

            PlayerTownCard playerLocation = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.HasSearchStation == false);
            Players[0].PlayerCards.Add(playerLocation);
            GameState.CurrentPlayer.Town = playerLocation.Town;


            ActionBase action = new BuildStationAction(GameState, GameState.CurrentPlayer);
            GameState.DoAction(action);

            Assert.IsNotNull(GameState.Board.GetTownSlot(playerLocation.Town.Name).Town.ControlDiseaseCenter);
            Assert.IsTrue(GameState.Board.GetTownSlot(playerLocation.Town.Name).HasSearchStation);
            Assert.AreEqual(3, GameState.ActionsRemaining);
            Assert.AreEqual(playerLocation, GameState.Board.PlayerDiscardCardStack.Peek());
        }

        [TestMethod]
        public void BuildStationWihthoutTownCardMustFails()
        {
            StartGame();

            PlayerTownCard playerLocation = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.HasSearchStation == false);
            Players[0].PlayerCards.Clear();
            GameState.CurrentPlayer.Town = playerLocation.Town;


            ActionBase action = new BuildStationAction(GameState, GameState.CurrentPlayer);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
                action.Execute();

            });
            Assert.IsNull(GameState.Board.GetTownSlot(TownsInitializer.Paris).Town.ControlDiseaseCenter);
            Assert.IsFalse(GameState.Board.GetTownSlot(TownsInitializer.Paris).Town.HasSearchStation);
        }



    }
}
