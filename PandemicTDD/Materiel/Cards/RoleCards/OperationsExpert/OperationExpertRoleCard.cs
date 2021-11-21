﻿using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    internal class OperationExpertRoleCard : RoleCard
    {

        public override List<Type> SpecialActions => specialActions;
        public List<Type> specialActions = new List<Type>()
        {
            typeof(OperationsExpertBuildStationAction),
            typeof(OperationExpertMoveFromStationToAnyTownAction)
        };




        public OperationExpertRoleCard(string name) : base(name)
        {
        }
    }
}