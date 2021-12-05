using PandemicTDD.Actions;
using PandemicTDD.Ressources;

namespace PandemicTDD.Materiel.PlayerCards
{
    public class PublicSubventionEventCard : EventPlayerCard
    {
        IPandemicRessource ressource;

        public override string Name => ressource.PublicSubventionEventName;

        public override string Description => ressource.PublicSubventionEventDescription;

        public PublicSubventionEventCard(IPandemicRessource ressource)
        {
            this.ressource = ressource;
        }


        public override ActionBase EventAction => throw new System.NotImplementedException();

  
    }
}