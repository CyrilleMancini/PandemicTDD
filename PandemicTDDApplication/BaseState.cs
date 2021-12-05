using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDD.Ressources;
using PandemicTDDApplication.Exceptions;
using PandemicTDDTests.Materiel;

namespace PandemicTDDApplication
{
    public abstract class BaseState
    {
        protected readonly IPandemicView View;

        protected readonly IPandemicRessource Ressources;

        protected GameState GameState { get; set; }

        protected BaseState(GameState gameState, IPandemicView view, IPandemicRessource Ressources)
        {
            GameState = gameState;
            this.View = view;
            this.Ressources = Ressources;
        }

        public abstract void Instructions();

        public virtual BaseState EnterPlayerName(string playerName) => throw new InvalidActionException(Ressources.ActionNotPermitted);

        public virtual BaseRoleState ChooseLevel(Difficulty difficulty) => throw new InvalidActionException(Ressources.ActionNotPermitted);

        public virtual BaseState DoAction() => throw new InvalidActionException(Ressources.ActionNotPermitted);

        public virtual BaseState SetNumberPlayer(int nbPlayers) => throw new InvalidActionException(Ressources.ActionNotPermitted);

        protected BaseRoleState GetStateFromCurrentPlayerRole()
        {
            switch (GameState.CurrentPlayer.Role)
            {
                case ScientistRoleCard sc:
                    return new State010_PlayScientistRole(GameState, View, Ressources);

                case ContingencyPlannerRoleCard sc:
                    return new State020_PlayContingencyPlannerRole(GameState, View, Ressources);

                case DispatcherRoleCard sc:
                    return new State030_DispatcherRole(GameState, View, Ressources);

                case ResearcherRoleCard sc:
                    return new State040_PlayResearcherRole(GameState, View, Ressources);

                case QuarantineSpecialistRoleCard sc:
                    return new State050_PlayQuarantineSpecialistRole(GameState, View, Ressources);

                case OperationExpertRoleCard sc:
                    return new State060_PlayOperationPlannerRole(GameState, View, Ressources);

                case MedicRoleCard sc:
                    return new State070_PlayMedicRole(GameState, View, Ressources);
            }
            return null;

        }

    }
}
