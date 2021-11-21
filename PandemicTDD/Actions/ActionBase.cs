namespace PandemicTDD.Actions
{
    public abstract class ActionBase
    {
        public abstract bool ConsumeOneAction { get; }

        public abstract void Try();

        public abstract void Execute();

    }
}
