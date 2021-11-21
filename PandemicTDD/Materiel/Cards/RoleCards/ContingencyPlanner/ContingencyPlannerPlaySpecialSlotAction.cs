using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;

namespace PandemicTDD.Materiel
{
    internal class ContingencyPlannerPlaySpecialSlotAction : ActionBase
    {

        public override bool ConsumeOneAction => true;

        private GameState GameState;

        public ContingencyPlannerRoleCard Role;

        public ContingencyPlannerPlaySpecialSlotAction(GameState gameState)
        {
            GameState = gameState;
        }

        public override void Execute()
        {
            Role.ExecuteSpecialSlot();
            Role.UseSpecialSlot();
        }

        public override void Try()
        {
            Role = (ContingencyPlannerRoleCard)GameState.CurrentPlayer.Role;

            if (Role is not ContingencyPlannerRoleCard)
                throw new InvalidPreconditionsException($"This action can only be bone by a Contingency Planner");

            Role.TrySpecialSlot();
        }
    }
}