using PandemicTDD.Actions;
using PandemicTDD.Ressources;

namespace PandemicTDD.Materiel.PlayerCards
{
    public class AirLiftEventCard : EventPlayerCard
    {
        IPandemicRessource ressource;

        public override string Name => ressource.AirLiftEventName;

        public override string Description => ressource.AirLiftEventDescription;

        public AirLiftEventCard(IPandemicRessource ressource)
        {
            this.ressource = ressource;
        }

        public override ActionBase EventAction => throw new System.NotImplementedException();

    }
}