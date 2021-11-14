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
    public class BuildResearchStationTests : TestsBase
    {

        [TestMethod]
        public void BuildStationOnOwnedTownCard()
        {
            StartGame();

            PlayerTownCard playerLocation = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Paris);
            Players[0].PlayerCards.Add(playerLocation);
            GameState.CurrentPlayer.Town = playerLocation.Town;


            ActionBase action = new BuildStationAction(GameState);
            GameState.DoAction(action);

            Assert.IsNotNull(GameState.Board.GetTownSlot(TownsInitializer.Paris).ControlDiseaseCenter);
            Assert.AreEqual(3, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void BuildStationWihthoutTownCard()
        {
            StartGame();

            PlayerTownCard playerLocation = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Paris);
            Players[0].PlayerCards.Clear();
            GameState.CurrentPlayer.Town = playerLocation.Town;


            ActionBase action = new BuildStationAction(GameState);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
                action.Execute();

            });
            Assert.IsNull(GameState.Board.GetTownSlot(TownsInitializer.Paris).ControlDiseaseCenter);
        }


    }
}
