using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;

namespace PandemicTDD
{
    public class Player
    {
        public string Name { get; set; }

        public RoleCard Role { get; set; } = null;

        public List<PlayerCard> PlayerCards { get; internal set; } = new List<PlayerCard>();

    }
}