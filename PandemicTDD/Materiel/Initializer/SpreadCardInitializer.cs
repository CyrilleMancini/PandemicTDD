using PandemicTDD.Materiel.Initializer.SpreadInitRules;
using PandemicTDD.Tools;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializer
{
    public class SpreadCardInitializer
    {

        ListShuffler listShuffler;
        private Draw3SpreadCardAndAdd3DiseasesOnIt Draw3SpreadCard;

        public SpreadCardInitializer()
        {
            listShuffler = new ListShuffler();
            Draw3SpreadCard = new Draw3SpreadCardAndAdd3DiseasesOnIt();
        }

        static List<SpreadCard> SingleSpreadCards = null;

        internal List<SpreadCard> InitCards(Board board)
        {
            {
                if (SingleSpreadCards == null)
                {
                    SingleSpreadCards = new List<SpreadCard>();

                    foreach (Town town in board.Towns)
                        SingleSpreadCards.Add(new SpreadCard(town));
                }

                SingleSpreadCards = listShuffler.Shuffle(SingleSpreadCards);                

                return SingleSpreadCards;
            }
        }
    }
}