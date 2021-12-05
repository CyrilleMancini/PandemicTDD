using PandemicTDD.Actions;
using PandemicTDD.Ressources;

namespace PandemicTDD.Materiel.PlayerCards
{
    public class CalmNigthEventCard : EventPlayerCard
    {
        IPandemicRessource ressource;

        public override string Name => ressource.CalmNigthEventName;

        public override string Description => ressource.CalmNigthEventDescription;

        public CalmNigthEventCard(IPandemicRessource ressource)
        {
            this.ressource = ressource;
        }
        public override ActionBase EventAction => throw new System.NotImplementedException();
    }

}