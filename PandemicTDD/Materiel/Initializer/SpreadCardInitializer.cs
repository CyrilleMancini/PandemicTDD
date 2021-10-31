using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializer
{
    public class SpreadCardInitializer
    {

        public SpreadCardInitializer()
        {

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
                return SingleSpreadCards;
            }
        }
    }
}