using Microsoft.AspNetCore.Components;
using PandemicTDD.Materiel;
using PandemicTDD.Ressources;
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

        [Parameter]
        public EventCallback<String> OnDestinationSelected { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        internal void Clear()
        {

        }

        bool visible = false;

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

        }

        internal void SetDestinations(Town[] destinations)
        {
            Destinations = destinations;
            Visible = true;
        }

        private void DestinationSelected(Town selected)
        {
            OnDestinationSelected.InvokeAsync(selected.Name);
            Visible = false;

        }

    }
}
