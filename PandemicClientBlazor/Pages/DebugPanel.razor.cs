using System;
using System.Collections.Generic;
using System.Globalization;

namespace PandemicClientBlazor.Pages
{
    public partial class DebugPanel : IDebuggableUI
    {

        bool Hidden = false;

        Dictionary<string, Action> DebugActions = new Dictionary<string, Action>();

        public void AddDebugAction(string Name, Action action)
        {
            if (!DebugActions.ContainsKey(Name))
                DebugActions.Add(Name, action);
            StateHasChanged();
        }

        private List<String> Logs = new List<string>();

        public void Log(String Message)
        {
            Logs.Insert(0, Message);
        }
    }

    public enum CoordinateFormat { XY, Css }

    public static class MousePositionFormatter
    {
        public static string Format(double x, double y, CoordinateFormat format) => format switch
        {
            CoordinateFormat.Css => string.Create(CultureInfo.InvariantCulture, $"left:{x}px;top:{y}px;"),
            _ => string.Create(CultureInfo.InvariantCulture, $"{x},{y}")
        };
    }

}
