﻿namespace PandemicTDD
{
    public interface IObserveGameState
    {
        void Error(string ErrorMessage);

        void Action(string ActionMessage);

    }
}
