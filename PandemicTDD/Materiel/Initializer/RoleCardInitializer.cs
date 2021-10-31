using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializer
{
    public class RoleCardInitializer
    {
        static List<RoleCard> SingleRoleCards;

        public List<RoleCard> InitCards()
        {
            if (SingleRoleCards == null)
            {
                SingleRoleCards = new List<RoleCard>() {
                        new RoleCard("Chercheuse"),
                        new RoleCard("Planificateur d'urgence"),
                        new RoleCard("Répartiteur"),
                        new RoleCard("Expert aux opérations"),
                        new RoleCard("Médecin"),
                        new RoleCard("Scientifique"),
                        new RoleCard("Spécialiste en mise en quarantaine"),
                };
            }
            return SingleRoleCards;
        }
    }
}