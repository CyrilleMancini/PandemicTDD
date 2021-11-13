namespace PandemicTDD.Materiel.Initializers
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