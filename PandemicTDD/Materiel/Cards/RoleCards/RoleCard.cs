using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public abstract class RoleCard
    {
        public string Name { get; set; }

        public abstract List<Type> SpecialActions { get; }

        public virtual void PlaySpecialAutoActions()
        {

        }

        public RoleCard(string name)
        {
            Name = name;
        }
    }

    public class UndefRoleCard : RoleCard
    {
        public override List<Type> SpecialActions => throw new NotImplementedException();

        public UndefRoleCard(string name) : base(name)
        {
        }
    }
}