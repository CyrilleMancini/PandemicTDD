using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class GameBox
    {
        public static List<RoleCard> GetRoles()
        {
            return new List<RoleCard>() {
            new RoleCard("Chercheuse"),
            new RoleCard("Planificateur d'urgence"),
            new RoleCard("Répartiteur"),
            new RoleCard("Expert aux opérations"),
            new RoleCard("Médecin"),
            new RoleCard("Scientifique"),
            new RoleCard("Spécialiste en mise en quarantaine"),
            };
        }
    }
}