using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class DispatcherRoleCard : RoleCard
    {
        public DispatcherRoleCard(string name) : base(name)
        {
        }

        public override List<Type> SpecialActions => new List<Type>()
        {
            typeof(DispatcherMoveAnotherPlayerByCharterFlightAsHisAction),
            typeof(DispatcherMoveAnotherPlayerByDirectFlightAsHisAction),
            typeof(DispatcherMoveAnotherPlayerByDriverFerryAsHisAction),
            typeof(DispatcherMoveAnotherPlayerByShuttleAsHis),
            typeof(DispatcherMovePlayerToAnotherPlayer),
        };
    }
}