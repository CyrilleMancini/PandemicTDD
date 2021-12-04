using Microsoft.AspNetCore.Components;
using PandemicTDD.Materiel;
using PandemicTDDApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandemicClientBlazor.Pages
{
    public partial class SelectDestination
    {
        [Inject]
        IPandemicRessource ressource { get; set; }

        Dictionary<string, Action> Actions = new Dictionary<string, Action>();
        Dictionary<string, string> Descriptions = new Dictionary<string, string>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        internal void Clear()
        {
            Actions.Clear();
        }

        public void AddAction(string Name, Action action)
        {
            Actions.Add(Name, action);
            StateHasChanged();
        }



        bool visible = false;
        private Town[] Destinations;

        [CascadingParameter]
        IDebuggableUI DebugPanel { get; set; }

        void DebugSwitchAction()
        {
            Visible = !visible;
        }
        protected override void OnParametersSet()
        {
            if (DebugPanel != null)
                DebugPanel.AddDebugAction("Switch Destinations", DebugSwitchAction);
            //base.OnInitialized();
        }

        [Parameter]
        public bool Visible
        {
            get => visible;
            set
            {
                visible = value;
                StateHasChanged();
            }
        }

        string Visibility { get => (Visible ? "block" : "none"); }

        internal string SetDestination(Town[] destinations)
        {
            Destinations = destinations;
            Visible = true;
            return destinations[0].Name;
        }
    }
}
