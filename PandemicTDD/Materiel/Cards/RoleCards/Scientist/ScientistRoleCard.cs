﻿using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    internal class ScientistRoleCard : RoleCard
    {
        public ScientistRoleCard(string name) : base(name)
        {
        }

        public override List<Type> SpecialActions => new List<Type>()
        {
        };
    }
}