using PandemicTDD;
using PandemicTDD.Ressources;

namespace PandemicTDDApplication
{
    internal class State030_DispatcherRole : BaseRoleState
    {
        public State030_DispatcherRole(GameState gameState, IPandemicView view, IPandemicRessource Ressources) : base(gameState, view, Ressources)
        {
        }

        protected override void AddSpecialActions()
        {
            throw new System.NotImplementedException();
        }
    }
}