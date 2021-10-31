using System.Drawing;

namespace PandemicTDD.Materiel
{
    public class Disease
    {
        public Color Color { get; private set; }

        public Disease(Color color)
        {
            Color = color;
        }
    }
}