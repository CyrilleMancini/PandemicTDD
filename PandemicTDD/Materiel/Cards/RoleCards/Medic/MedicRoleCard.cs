﻿using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    public class MedicRoleCard : RoleCard
    {
        public MedicRoleCard(string name) : base(name)
        {
        }

        public override List<Type> SpecialActions => new List<Type>()
        {

        };

    }
}