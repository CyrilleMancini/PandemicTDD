using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    internal class GameBox
    {
        internal static List<RoleCard> GetRoles()
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