using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class ResearcherRoleCard : RoleCard
    {
        public override List<Type> SpecialActions => specialActions;
        public List<Type> specialActions = new List<Type>()
        {
            typeof(ReseacherShareKnowledgeAction),
        };

        public ResearcherRoleCard(string name) : base(name)
        {

        }
    }
}