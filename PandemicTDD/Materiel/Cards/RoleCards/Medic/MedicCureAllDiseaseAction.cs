using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    internal class MedicCureAllDiseaseAction : ActionBase
    {
        private GameState gameState;
        private readonly DiseaseColor diseaseColor;

        public MedicCureAllDiseaseAction(GameState gameState, DiseaseColor diseaseColor)
        {
            this.gameState = gameState;
            this.diseaseColor = diseaseColor;
        }

        public override bool ConsumeOneAction => true;

        public override void Execute()
        {
            List<DiseaseCube> cubes = gameState.CurrentPlayer.Town.GetDiseaseByColor(diseaseColor);
            gameState.GameBox.GetDiseaseBags().AddCubes(cubes);
            gameState.CurrentPlayer.Town.CureDiseaseByColor(diseaseColor);
        }

        public override void Try()
        {
        }
    }
}