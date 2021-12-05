using PandemicTDD.Actions;

namespace PandemicTDD.Materiel.PlayerCards
{
    public abstract class EventPlayerCard : PlayerCard
    {
        public override string Type => "Event";

        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract ActionBase EventAction { get; }

    }
}