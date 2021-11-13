namespace PandemicTDD.Materiel.Initializers
{
    public class DiseaseBagsInitializer
    {
        static DiseaseBags SingleBags;

        internal DiseaseBags InitBags()
        {
            if (SingleBags == null)
            {
                SingleBags = new DiseaseBags();
                for (int i = 0; i < 24; i++)
                {
                    SingleBags.Blacks.Add(new DiseaseCube(DiseaseColor.Black));
                    SingleBags.Reds.Add(new DiseaseCube(DiseaseColor.Red));
                    SingleBags.Yellows.Add(new DiseaseCube(DiseaseColor.Yellow));
                    SingleBags.Blues.Add(new DiseaseCube(DiseaseColor.Blue));
                }
            }
            return SingleBags;
        }

        internal void Reset()
        {
            if (SingleBags == null) return;
            SingleBags.Blacks.Clear();
            SingleBags.Reds.Clear();
            SingleBags.Yellows.Clear();
            SingleBags.Blues.Clear();
            SingleBags = null;
        }
    }
}