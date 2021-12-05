using PandemicTDD.Actions;
using PandemicTDD.Ressources;

namespace PandemicTDD.Materiel.PlayerCards
{
    public class ForcastEventCard : EventPlayerCard
    {
        IPandemicRessource ressource;

        public override string Name => ressource.ForcastEventName;

        public override string Description => ressource.ForcastEventDescription;

        public ForcastEventCard(IPandemicRessource ressource)
        {
            this.ressource = ressource;
        }

        public override ActionBase EventAction => throw new System.NotImplementedException();
    }




}