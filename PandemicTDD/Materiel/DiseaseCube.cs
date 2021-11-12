using System.Drawing;

namespace PandemicTDD.Materiel
{
    public class DiseaseCube
    {
        public DiseaseColor Color { get; private set; }

        public DiseaseCube(DiseaseColor color)
        {
            Color = color;
        }
    }
}