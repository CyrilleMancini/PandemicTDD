using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    internal class MedicCureAllDiseaseAction : ActionBase
    {
        private GameState gameState;
        private List<DiseaseCube> cubes;
        private readonly DiseaseColor diseaseColor;

        public MedicCureAllDiseaseAction(GameState gameState, DiseaseColor diseaseColor)
        {
            this.gameState = gameState;
            this.diseaseColor = diseaseColor;
        }

        public override bool ConsumeOneAction => true;

        public override void Execute()
        {
            gameState.GameBox.GetDiseaseBags().AddCubes(cubes);
            gameState.CurrentPlayer.Town.CureDiseaseByColor(diseaseColor);
        }

        public override void Try()
        {
            cubes = gameState.CurrentPlayer.Town.GetDiseaseByColor(diseaseColor);
            if (cubes.Count == 0)
                throw new InvalidPreconditionsException($"No Any disease {diseaseColor} on that town.");
        }
    }
}