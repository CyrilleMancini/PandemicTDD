using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    [TestClass]
    public class ShareKnowledgeActionTest : TestsBase
    {

        [TestMethod]
        public void PlayerMustBeInTheSameTown()
        {
            StartGame();

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Atlanta).Town;

            string CardToShare = TownsInitializer.Paris;

            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            Assert.ThrowsException<PlayerInDifferentTownsException>(() =>
            {
                action.Try();
            });

        }

        [TestMethod]

        public void PLayersMustBeInTheSharedTown()
        {
            StartGame();

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;

            string CardToShare = TownsInitializer.Atlanta;

            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            Assert.ThrowsException<PlayersMustBeInTheShareTownCardException>(() =>
            {
                action.Try();
            });

        }

        [TestMethod]
        public void PlayersMustHaveTheSharedCardTest()
        {
            StartGame();

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;

            string CardToShare = TownsInitializer.Paris;
            Players[0].PlayerCards.Clear();
            Players[1].PlayerCards.Clear();
            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
                action.Execute();
            });

        }

        [TestMethod]
        public void GiveCard()
        {
            StartGame();

            PlayerTownCard OrigineCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct);

            Players[0].Town = GameState.Board.GetTownSlot(OrigineCard.Town.Name).Town;
            Players[1].Town = GameState.Board.GetTownSlot(OrigineCard.Town.Name).Town;

            string CardToShare = OrigineCard.Town.Name;

            Players[0].PlayerCards.Add(OrigineCard);

            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            GameState.DoAction(action);

            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                Players[0].GetCityPlayerCard<PlayerTownCard>(CardToShare);
            });
            Players[1].GetCityPlayerCard<PlayerTownCard>(CardToShare);
        }


        [TestMethod]
        public void TakeCard()
        {
            StartGame();

            PlayerTownCard OrigineCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct);
            string CardToShare = OrigineCard.Town.Name;
            Players[0].Town = GameState.Board.GetTownSlot(OrigineCard.Town.Name).Town;
            Players[1].Town = GameState.Board.GetTownSlot(OrigineCard.Town.Name).Town;
            Players[1].PlayerCards.Add(OrigineCard);


            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            GameState.DoAction(action);

            Players[0].GetCityPlayerCard<PlayerTownCard>(CardToShare);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                Players[1].GetCityPlayerCard<PlayerTownCard>(CardToShare);
            });
        }



    }
}
