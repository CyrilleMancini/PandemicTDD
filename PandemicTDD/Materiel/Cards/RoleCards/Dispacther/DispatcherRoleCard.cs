using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    internal class DispatcherRoleCard : RoleCard
    {
        public DispatcherRoleCard(string name) : base(name)
        {
        }

        public override List<Type> SpecialActions => new List<Type>()
        {
        };
    }
}