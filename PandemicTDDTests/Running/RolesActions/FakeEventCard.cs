using PandemicTDD.Actions;
using PandemicTDD.Materiel.PlayerCards;

namespace PandemicTDDTests.Materiel
{

    public class FakeEventCard : EventPlayerCard
    {
        ActionBase action = new FakeEventCardAction();
        public override ActionBase EventAction => action;

        public override string Name => "Fake Name";

        public override string Description => "Fake Description";
    }
}