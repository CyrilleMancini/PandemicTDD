using System.Drawing;

namespace PandemicTDD.Materiel.Initializer
{
    public class DiseaseBagsInitializer
    {
        internal DiseaseBags InitBags()
        {
            {

                var bags = new DiseaseBags();
                for (int i = 0; i < 24; i++)
                {
                    bags.Blacks.Add(new DiseaseCube(Color.Black));
                    bags.Reds.Add(new DiseaseCube(Color.Red));
                    bags.Yellows.Add(new DiseaseCube(Color.Yellow));
                    bags.Blues.Add(new DiseaseCube(Color.Blue));
                }
                return bags;
            }

        }
    }
}