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

        public static bool operator ==(Town t1, Town t2)
        {
            if (t1 is null && t2 is null) return true;

            return t1.Equals(t2);
        }
        public static bool operator !=(Town t1, Town t2)
        {
            if (t1 == null && t2 == null) return false;

            return !t1.Equals(t2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Town t)
                return t.Name == Name && t.Color == Color && t.Pays == Pays;

            return false;
        }
    }
}