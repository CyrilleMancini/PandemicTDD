using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    internal class QuarantineSpecialistRoleCard : RoleCard
    {
        public QuarantineSpecialistRoleCard(string name) : base(name)
        {
        }

        public override List<Type> SpecialActions => new List<Type>()
        {

        };
    }
}