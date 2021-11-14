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
    public class ShareKnowledgeActionTest : TestsBase
    {

        [TestMethod]
        public void PlayerMustBeInTheSameTown()
        {
            StartGame();

            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Paris).Town;
            Players[1].Town = GameState.Board.GetTownSlot(TownsInitializer.Atlanta).Town;

            string CardToShare = "Paris";

            ActionBase action = new ShareKnowledgeAction(GameState, Players[1], CardToShare);
            Assert.ThrowsException<PlayerInDifferentTownsException>(() =>
            {
                action.Try();
            });

        }

    }
}
