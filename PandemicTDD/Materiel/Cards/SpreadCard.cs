namespace PandemicTDD.Materiel
{
    public class SpreadCard
    {
        public Town Town { get; }

        public SpreadCard(Town town)
        {
            Town = town;
        }

        public override string ToString()
        {
            return Town.ToString();
        }
    }
}