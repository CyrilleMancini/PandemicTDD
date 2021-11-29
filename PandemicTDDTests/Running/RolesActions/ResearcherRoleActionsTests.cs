using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class ResearcherRoleActionsTests : TestsBase
    {
        [TestMethod()]
        public void ResearcherShareActionSuccess()
        {
            GameBox.GetInitializedBoard();

            Players[0].Role = GameBox.GetRoles().First(c => c is ResearcherRoleCard);

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;
            GameState.SetPlayers(Players);

            string CardToShare = TownsInitializer.Paris;
            PlayerCard OrigineCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Paris);
            Players[0].PlayerCards.Add(OrigineCard);


            ActionBase action = new ReseacherShareKnowledgeAction(GameState, Players[1], CardToShare);
            GameState.DoAction(action);
            Assert.AreEqual(null, ConsoleObserver.LastErrorReceived);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                Players[0].GetCityPlayerCard<PlayerTownCard>(CardToShare);
            });
            Players[1].GetCityPlayerCard<PlayerTownCard>(CardToShare);
        }

        [TestMethod()]
        public void ResearcherShareActionFailIfGiverIsNotResearcher()
        {
            GameBox.GetInitializedBoard();

            Players[0].Role = GameBox.GetRoles().First(c => c is ResearcherRoleCard);

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;
            GameState.SetPlayers(Players);

            string CardToShare = TownsInitializer.Paris;
            PlayerCard OrigineCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name != TownsInitializer.Londres);
            Players[1].PlayerCards.Add(OrigineCard);


            ActionBase action = new ReseacherShareKnowledgeAction(GameState, Players[1], CardToShare);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
            });
        }

        [TestMethod()]
        public void ResearcherShareActionFailIfNotInTheSameCity()
        {
            GameBox.GetInitializedBoard();

            Players[0].Role = GameBox.GetRoles().First(c => c is ResearcherRoleCard);

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;
            GameState.SetPlayers(Players);

            string CardToShare = TownsInitializer.Paris;
            PlayerCard OrigineCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Red);
            Players[1].PlayerCards.Add(OrigineCard);


            ActionBase action = new ReseacherShareKnowledgeAction(GameState, Players[1], CardToShare);
            Assert.ThrowsException<PlayerInDifferentTownsException>(() =>
            {
                action.Try();
            });
        }

        [TestMethod()]
        public void ResearcherShareActionFailIfGiverOtherIsNotResearcher()
        {
            GameBox.GetInitializedBoard();

            Players[1].Role = GameBox.GetRoles().First(c => c is ResearcherRoleCard);

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;
            GameState.SetPlayers(Players);

            string CardToShare = TownsInitializer.Paris;
            PlayerCard OrigineCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Red);
            Players[1].PlayerCards.Add(OrigineCard);


            ActionBase action = new ReseacherShareKnowledgeAction(GameState, Players[1], CardToShare);
            Assert.ThrowsException<PlayerInDifferentTownsException>(() =>
            {
                action.Try();
            });
        }
    }
}