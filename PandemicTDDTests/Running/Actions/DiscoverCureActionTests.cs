using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    [TestClass]
    public class DiscoverCureActionTests : TestsBase
    {

        [TestMethod]
        public void PlayerMustBeInTownWithSearchStation()
        {
            StartGame();
            GameBox.GetBoard();

            GameState.Board.GetTownSlot(TownsInitializer.Atlanta).ControlDiseaseCenter = null;
            List<PlayerTownCard> cards = new();

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            Assert.ThrowsException<CityWithoutControlCenterException>(() =>
            {
                action.Try();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void PlayerMustHaveFiveCardFromDiseaseColor()
        {
            StartGame();
            GameBox.GetBoard();

            List<PlayerTownCard> cards = new();

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            Assert.ThrowsException<NotEnoughCardToFindCureException>(() =>
            {
                action.Try();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }


        [TestMethod]
        public void BlackCureDiscovered()
        {
            StartGame();
            GameBox.GetBoard();
            GameBox.Reset();
            List<PlayerTownCard> cards = new();
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Alger));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Le_Caire));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Bagdad));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Riyad));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Istanbul));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().BlackSlot.Status);
        }


        [TestMethod]
        public void BlueCureDiscovered()
        {
            StartGame();
            GameBox.GetBoard();
            GameBox.Reset();
            List<PlayerTownCard> cards = new();
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Atlanta));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Washington));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Chicago));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.San_Francisco));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Londres));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Blue, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().BlueSlot.Status);
        }


        [TestMethod]
        public void RedCureDiscovered()
        {
            StartGame();
            GameBox.GetBoard();
            GameBox.Reset();
            List<PlayerTownCard> cards = new();
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Manille));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Sydney));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Séoul));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Shanghai));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Hong_Kong));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Red, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().RedSlot.Status);
        }
        [TestMethod]
        public void YellowCureDiscovered()
        {
            StartGame();
            GameBox.GetBoard();
            GameBox.Reset();
            List<PlayerTownCard> cards = new();
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Lima));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Santiago));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Sao_Paulo));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Miami));
            cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Bogota));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Yellow, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().YellowSlot.Status);
        }
    }
}
