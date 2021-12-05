using System;

namespace PandemicClientBlazor.Pages
{
    internal interface IDebuggableUI
    {

        void AddDebugAction(string Name, Action action);
        void Log(string Message);
    }
}