using PandemicTDD.Materiel.PlayerCards;
using PandemicTDD.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{
    internal class PreparePlayerCardsStack
    {
        private ListShuffler ListShuffler;

        public PreparePlayerCardsStack()
        {
            ListShuffler = new ListShuffler();
        }

        internal void ExecuteRule(GameBox gameBox)
        {
            // Take Epidemic Cards
            List<PlayerCard> epidemics = gameBox.GetPlayersCard()
                                                .Where(c => c is EpidemicPlayerCard)
                                                .ToList();

            // Take All Ohter Cards
            List<PlayerCard> OtherCards = gameBox.GetPlayersCard()
                                                .Where(c => !(c is EpidemicPlayerCard))
                                                .ToList();

            // Create as many stack as epidemic cards
            List<List<PlayerCard>> TmpStack = new List<List<PlayerCard>>();

            int NbCardByStack = OtherCards.Count / epidemics.Count;
            for (int i = 0; i < epidemics.Count; i++)
            {
                TmpStack.Add(new List<PlayerCard>());
                TmpStack[i].AddRange(OtherCards.GetRange(0, Math.Min(NbCardByStack, OtherCards.Count)));
                OtherCards.RemoveRange(0, Math.Min(NbCardByStack, OtherCards.Count));

                TmpStack[i].Add(epidemics[0]);
                //epidemics.RemoveAt(0);

                TmpStack[i] = ListShuffler.Shuffle<PlayerCard>(TmpStack[i]);

            }
            OtherCards.ForEach(card => gameBox.GetBoard().PlayerCardStack.Push(card));


            TmpStack.SelectMany(it => it)
                        .ToList()
                        .ForEach(card => gameBox.GetBoard().PlayerCardStack.Push(card));


        }
    }
}