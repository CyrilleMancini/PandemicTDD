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


            DrawNSpreadCardsAndAddNDiseasesOnIt drawSpreadCardssAndAddDiseasesOnIt = new DrawNSpreadCardsAndAddNDiseasesOnIt();
            drawSpreadCardssAndAddDiseasesOnIt.ExecuteRule(3, gameBox);
            
            drawSpreadCardssAndAddDiseasesOnIt.ExecuteRule(2, gameBox);

            drawSpreadCardssAndAddDiseasesOnIt.ExecuteRule(1, gameBox);
        }
    }
}