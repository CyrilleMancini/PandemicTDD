using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    public class QuarantineSpecialistRoleCard : RoleCard
    {
        public QuarantineSpecialistRoleCard(string name) : base(name)
        {
        }

        public override List<Type> SpecialActions => new List<Type>()
        {

        };
    }
}