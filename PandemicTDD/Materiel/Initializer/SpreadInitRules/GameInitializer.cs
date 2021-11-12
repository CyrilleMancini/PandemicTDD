using PandemicTDD.Materiel.Initializer.SpreadInitRules;
using System;

namespace PandemicTDD.Materiel
{
    public class GameInitializer
    {
        internal void InitGame(GameBox gameBox)
        {
            FillSpreadCardsStack fillSpreadCardsStack = new FillSpreadCardsStack();
            fillSpreadCardsStack.ExecuteRule(gameBox);


            Draw3SpreadCardAndAdd3DiseasesOnIt draw3SpreadCardAndAdd3DiseasesOnIt = new Draw3SpreadCardAndAdd3DiseasesOnIt();
            draw3SpreadCardAndAdd3DiseasesOnIt.ExecuteRule(gameBox);
        }
    }
}