using System;

namespace PandemicTDD.Materiel.Initializer.SpreadInitRules
{
    internal class FillSpreadCardsStack
    {
        public FillSpreadCardsStack()
        {
        }

        internal void ExecuteRule(GameBox gameBox)
        {
            gameBox.GetSpeadCards().ForEach(c => gameBox.GetBoard().SpreadStack.Push(c));
        }
    }
}