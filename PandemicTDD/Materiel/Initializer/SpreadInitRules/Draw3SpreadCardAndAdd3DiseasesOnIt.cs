using System;

namespace PandemicTDD.Materiel.Initializer.SpreadInitRules
{
    internal class Draw3SpreadCardAndAdd3DiseasesOnIt
    {
        public Draw3SpreadCardAndAdd3DiseasesOnIt()
        {
        }

        internal void ExecuteRule(GameBox board)
        {
            for (int i = 0; i < 3; i++)
            {
                SpreadCard card = board.GetBoard().SpreadStack.Pop();
                board.GetBoard().SpreadDiscardStack.Push(card);
            }
        }
    }
}