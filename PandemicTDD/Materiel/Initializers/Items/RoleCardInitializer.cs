using PandemicTDDTests.Materiel;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{
    public class RoleCardInitializer
    {
        static List<RoleCard> SingleRoleCards;

        public List<RoleCard> InitCards()
        {
            if (SingleRoleCards == null)
            {
                SingleRoleCards = new List<RoleCard>() {
                        new ResearcherRoleCard("Chercheuse"),
                        new ContingencyPlannerRoleCard("Planificateur d'urgence"),
                        new DispatcherRoleCard("Répartiteur"),
                        new OperationExpertRoleCard("Expert aux opérations"),
                        new MedicRoleCard("Médecin"),
                        new ScientistRoleCard("Scientifique"),
                        new UndefRoleCard("Spécialiste en mise en quarantaine"),
                };
            }
            return SingleRoleCards;
        }

        public void Reset()
        {
            if (SingleRoleCards == null) return;
            SingleRoleCards.Clear();
            SingleRoleCards = null;
        }

    }
}