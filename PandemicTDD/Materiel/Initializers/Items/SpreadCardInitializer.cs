using PandemicTDD.Tools;
using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{
    public class SpreadCardInitializer
    {
        ListShuffler listShuffler;

        public SpreadCardInitializer()
        {
            listShuffler = new ListShuffler();
        }

        static List<SpreadCard> SingleSpreadCards = null;

        internal List<SpreadCard> InitCards(Board board)
        {

            if (SingleSpreadCards == null)
            {
                SingleSpreadCards = new List<SpreadCard>();

                foreach (Town town in board.Towns)
                    SingleSpreadCards.Add(new SpreadCard(town));

                SingleSpreadCards = listShuffler.Shuffle(SingleSpreadCards);

            }
            return SingleSpreadCards;

        }

        internal void Reset()
        {
            if (SingleSpreadCards == null) return;
            SingleSpreadCards.Clear();
            SingleSpreadCards = null;
        }
    }
}
