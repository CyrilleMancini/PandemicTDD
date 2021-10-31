using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class GameBox
    {
        static List<RoleCard> SingleRoleCards = null;
        public static List<RoleCard> GetRoles()
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


        static List<PlayerCard> SinglePlayerCards = null;
        public static List<PlayerCard> GetPlayersCard()
        {
            if (SinglePlayerCards == null)
            {
                SinglePlayerCards = new List<PlayerCard>();

                for (int i = 0; i < 48; i++)
                    SinglePlayerCards.Add(new PlayerTownCard());

                for (int i = 0; i < 6; i++)
                    SinglePlayerCards.Add(new EpidemicPlayerCard());

                for (int i = 0; i < 5; i++)
                    SinglePlayerCards.Add(new EventPlayerCard());
            }
            return SinglePlayerCards;
        }

        static Board SingleBoard = null;
        public static Board GetBoard()
        {
            if (SingleBoard == null)
                SingleBoard = new Board();

            return SingleBoard;
        }
    }
}