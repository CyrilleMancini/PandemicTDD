using PandemicTDD.Materiel;

namespace PandemicTDD.Actions
{
    internal class TreatDiseaseAction : ActionBase
    {
        private GameState GameState;
        private DiseaseColor Disease;

        public TreatDiseaseAction(GameState gameState, DiseaseColor disease)
        {
            GameState = gameState;
            Disease = disease;
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