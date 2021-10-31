using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Drawing;

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

        public static DiseaseBags GetDiseaseBags()
        {

            var bags = new DiseaseBags();
            for (int i = 0; i < 24; i++)
            {
                bags.Blacks.Add(new Disease(Color.Black));
                bags.Reds.Add(new Disease(Color.Red));
                bags.Yellows.Add(new Disease(Color.Yellow));
                bags.Blues.Add(new Disease(Color.Blue));
            }
            return bags;
        }

        static List<SpreadCard> SingleSpreadCards = null;
        public static List<SpreadCard> GetSpeadCards()
        {
            if (SingleSpreadCards == null)
            {
                SingleSpreadCards = new List<SpreadCard>();

                foreach (Town town in GetBoard().Towns)
                    SingleSpreadCards.Add(new SpreadCard(town));
            }
            return SingleSpreadCards;
        }

        static List<PlayerCard> SinglePlayerCards = null;
        public static List<PlayerCard> GetPlayersCard()
        {
            if (SinglePlayerCards == null)
            {
                SinglePlayerCards = new List<PlayerCard>();

                foreach (Town town in GetBoard().Towns)
                    SinglePlayerCards.Add(new PlayerTownCard(town));

                for (int i = 0; i < 6; i++)
                    SinglePlayerCards.Add(new EpidemicPlayerCard());

                // Add Event Card
                SinglePlayerCards.Add(new AirLiftEventCard());
                SinglePlayerCards.Add(new CalmNigthEventCard());
                SinglePlayerCards.Add(new ResilientPopulationEventCard());
                SinglePlayerCards.Add(new ForcastEventCard());
                SinglePlayerCards.Add(new PublicSubventionEventCard());
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