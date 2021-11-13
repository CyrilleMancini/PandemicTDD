using PandemicTDD.Materiel.Initializer.SpreadInitRules;
using System;

namespace PandemicTDD.Materiel.Initializer
{
    public class GameInitializer
    {
        internal void InitGame(GameBox gameBox)
        {
            FillSpreadCardsStack fillSpreadCardsStack = new FillSpreadCardsStack();
            fillSpreadCardsStack.ExecuteRule(gameBox);

            gameBox.GetBoard().GetTownSlots().ForEach(t => t.Town.ResetDiseases());

            DiseasesInitializer diseasesInit = new DiseasesInitializer();
            diseasesInit.ExecuteRule(3, gameBox);
            diseasesInit.ExecuteRule(2, gameBox);
            diseasesInit.ExecuteRule(1, gameBox);
        }
    }
}