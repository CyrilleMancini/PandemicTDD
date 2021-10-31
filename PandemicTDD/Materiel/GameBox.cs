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

        public static List<PlayerCard> GetPlayersCard()
        {
            var cards = new List<PlayerCard>();

            for (int i = 0; i < 48; i++)
                cards.Add(new PlayerTownCard());

            for (int i = 0; i < 6; i++)
                cards.Add(new EpidemicPlayerCard());

            for (int i = 0; i < 5; i++)
                cards.Add(new PlayerCard());

            return cards;
        }

        public static Board GetBoard()
        {
            return new Board();
        }
    }
}