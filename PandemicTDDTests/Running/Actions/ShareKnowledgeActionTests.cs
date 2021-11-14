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
            Assert.ThrowsException<PlayersMustBeInTheShareTownCard>(() =>
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

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;

            string CardToShare = TownsInitializer.Paris;
            PlayerCard OrigineCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Paris);
            Players[0].PlayerCards.Add(OrigineCard);


            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            GameState.DoAction(action);

            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                Players[0].GetCityPlayerCard(CardToShare);
            });
            Players[1].GetCityPlayerCard(CardToShare);
        }


        [TestMethod]
        public void TakeCard()
        {
            StartGame();

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;

            string CardToShare = TownsInitializer.Paris;
            PlayerCard OrigineCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name == TownsInitializer.Paris);
            Players[1].PlayerCards.Add(OrigineCard);


            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            GameState.DoAction(action);

            Players[0].GetCityPlayerCard(CardToShare);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                Players[1].GetCityPlayerCard(CardToShare);
            });
        }
    }
}
