using System.Drawing;

namespace PandemicTDD.Materiel
{
    public class DiseaseCube
    {
        public Color Color { get; private set; }

        public DiseaseCube(Color color)
        {
            Color = color;
        }
    }
}