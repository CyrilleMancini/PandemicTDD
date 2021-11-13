namespace PandemicTDD.Materiel.PlayerCards
{
    public class PlayerTownCard : PlayerCard
    {
        public override string Type => "Town";

        public Town Town { get; set; }

        public PlayerTownCard(Town town)
        {
            Town = town;
        }
    }
}