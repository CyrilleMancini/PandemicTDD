using PandemicTDD.Actions;
using PandemicTDD.Ressources;

namespace PandemicTDD.Materiel.PlayerCards
{
    public class ResilientPopulationEventCard : EventPlayerCard
    {

        IPandemicRessource ressource;

        public override string Name => ressource.ResilientPopulationEventName;

        public override string Description => ressource.ResilientPopulationEventDescription;

        public ResilientPopulationEventCard(IPandemicRessource ressource)
        {
            this.ressource = ressource;
        }
        public override ActionBase EventAction => throw new System.NotImplementedException();

    }
}