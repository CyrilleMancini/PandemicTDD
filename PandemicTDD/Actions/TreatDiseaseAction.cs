using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Running.Actions
{
    internal class TreatDiseaseAction : ActionBase
    {
        private GameState GameState;
        private DiseaseColor Disease;

        public TreatDiseaseAction(GameState gameState, DiseaseColor disease)
        {
            this.GameState = gameState;
            this.Disease = disease;
        }

        public override void Execute()
        {
            string town = GameState.CurrentPlayer.Town.Name;
            GameState.Board.GetTownSlot(town).Town.TreatOneCubeDisease(Disease);
            GameState.Result($"One {Disease} disease treated in {town}");
        }

        public override void Try()
        {
        }
    }
}