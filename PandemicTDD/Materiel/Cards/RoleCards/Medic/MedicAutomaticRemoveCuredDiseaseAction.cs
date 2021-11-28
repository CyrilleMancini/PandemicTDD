using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDDTests.Materiel;
using System;
using System.Linq;

namespace PandemicTDD.Materiel
{
    internal class MedicAutomaticRemoveCuredDiseaseAction : ActionBase
    {
        private GameState gameState;
        private Player MedicPlayer;

        public MedicAutomaticRemoveCuredDiseaseAction(GameState gameState)
        {
            this.gameState = gameState;
        }

        public override bool ConsumeOneAction => false;

        public override void Execute()
        {

            if (MedicPlayer == null) return;

            if (gameState.Board.GetCureSlots().BlackSlot.Status != DiseaseStatus.None)
                CureDisease(DiseaseColor.Black);

            if (gameState.Board.GetCureSlots().BlueSlot.Status != DiseaseStatus.None)
                CureDisease(DiseaseColor.Blue);

            if (gameState.Board.GetCureSlots().RedSlot.Status != DiseaseStatus.None)
                CureDisease(DiseaseColor.Red);

            if (gameState.Board.GetCureSlots().YellowSlot.Status != DiseaseStatus.None)
                CureDisease(DiseaseColor.Yellow);

        }

        private void CureDisease(DiseaseColor disease)
        {
            var cubes = MedicPlayer.Town.GetDiseaseByColor(disease);
            if (cubes.Count > 0)
            {
                gameState.GameBox.GetDiseaseBags().AddCubes(cubes);
                MedicPlayer.Town.CureDiseaseByColor(disease);
            }
        }

        public override void Try()
        {
            MedicPlayer = gameState.Players.FirstOrDefault(p => p.Role is MedicRoleCard);
         

        }
    }
}