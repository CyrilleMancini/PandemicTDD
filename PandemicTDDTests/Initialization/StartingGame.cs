using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class StartingGame : TestsBase
    {

        [TestMethod]
        public void InitPlayersMax4Players()
        {

            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
                new() { Name ="PlThree" },
                new() { Name ="PlFour" },
                new() { Name ="PlFive" },
            };
            Assert.ThrowsException<TooManyPlayersException>(() =>
            {
                GameBox.StartGame(Players);
            });
        }

        [TestMethod]
        public void InitPlayersMin2Players()
        {

            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
            };
            Assert.ThrowsException<NotEnoughPlayersException>(() =>
            {
                GameBox.StartGame(Players);
            });
        }

        [TestMethod]
        public void RolesDistibuted()
        {

            List<Player> Players = new List<Player>() {
             new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
                new() { Name ="PlThree" },
                new() { Name ="PlFour" },
               };
            GameBox.StartGame(Players);
            Assert.IsNotNull(Players[0].Role);
            Assert.IsNotNull(Players[1].Role);
            Assert.IsNotNull(Players[2].Role);
            Assert.IsNotNull(Players[3].Role);

        }

    }

}
