namespace PandemicTDD.Materiel
{
    public class Town
    {

        public string Color { get; }

        public string Name { get; }

        public string Pays { get; }

        public Town(string color, string name, string pays)
        {
            Color = color;
            Name = name;
            Pays = pays;
        }
    }
}