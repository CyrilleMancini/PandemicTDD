using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{
    internal class DistributeRolesRule
    {
        public DistributeRolesRule()
        {
        }
        Random r = new Random(Guid.NewGuid().GetHashCode());

        internal void ExecuteRule(GameBox gameBox, List<Player> players)
        {
            List<RoleCard> roles = gameBox.GetRoles();
            foreach (Player p in players)
            {
                int roleIdx = r.Next(0, roles.Count);
                p.Role = roles[roleIdx];
                roles.RemoveAt(roleIdx);
            }
        }
    }
}