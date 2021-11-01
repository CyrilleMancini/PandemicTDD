namespace PandemicTDD.Materiel
{
    public class TownSlot
    {
        public Town Town { get; private set; }

        public TownSlot(Town town)
        {
            Town = town;
        }

    }
}