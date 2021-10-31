using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    internal class GameBox
    {
        internal static List<RoleCard> GetRoles()
        {
            return new List<RoleCard>() {
            new RoleCard(),
            new RoleCard(),
            new RoleCard(),
            new RoleCard(),
            new RoleCard(),
            new RoleCard(),
            new RoleCard(),
            };
        }
    }
}