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
                    bags.Blacks.Add(new DiseaseCube(DiseaseColor.Black));
                    bags.Reds.Add(new DiseaseCube(DiseaseColor.Red));
                    bags.Yellows.Add(new DiseaseCube(DiseaseColor.Yellow));
                    bags.Blues.Add(new DiseaseCube(DiseaseColor.Blue));
                }
                return bags;
            }

        }
    }
}