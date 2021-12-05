using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandemicClientBlazor.Pages
{
    public partial class DebugPanel : IDebuggableUI
    {

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
}
