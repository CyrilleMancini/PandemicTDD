using Microsoft.AspNetCore.Components;
using PandemicTDDApplication;
using System;
using System.Collections.Generic;

namespace PandemicClientBlazor.Pages
{
    public partial class PlayerActions
    {
        [Inject]
        IPandemicRessource ressource { get; set; }

        Dictionary<string, Action> Actions = new Dictionary<string, Action>();
        Dictionary<string, string> Descriptions = new Dictionary<string, string>();

        protected override void OnInitialized()
        {
            Descriptions[ressource.Action_BuildStation] = @"Défaussez la carte Ville correspondant à la ville où se trouve votre pion afi n 
            d’y construire une station de recherche. Prenez une station de recherche
            de la réserve située à côté du plateau.Si les 6 stations de recherche ont été
            construites, déplacez celle que vous voulez sur la ville que vous occupez.";

            Descriptions[ressource.Action_DriveFerry] = @"Déplacez votre pion entre deux villes reliées par une ligne blanche";

            Descriptions[ressource.Action_DirectFlight] = @"Défaussez une carte Ville pour déplacer votre pion sur la ville 
            correspondant à la carte défaussée.";

            Descriptions[ressource.Action_CharterFlight] = @"Défaussez la carte Ville correspondant à la ville où se trouve votre pion 
            pour le déplacer sur la ville de votre choix.";
            Descriptions[ressource.Action_ShuttleFlight] = @"Déplacez vous d'une station a l'autre.";


            Descriptions[ressource.Action_TreatDisease] = @"Retirez 1 cube de maladie de la ville que vous occupez et remettez-le dans 
            la réserve. Si le remède de cette couleur a été découvert (voir ci-dessous), 

            retirez plutôt tous les cubes de cette couleur de la ville.
            Si le dernier cube d’une maladie guérie (dont le remède a été trouvé) est 
            retiré du plateau, cette maladie est éradiquée. Retournez le marqueur 
            Remède pour qu’il soit du côté";

            Descriptions[ressource.Action_ShareKnowledge] = @"Vous pouvez réaliser cette action de deux façons :
            •  donner à un autre joueur la carte Ville indiquant la ville où vous êtes, OU
            •  prendre d’un autre joueur la carte Ville indiquant la ville où vous êtes. 
            L’autre joueur et vous devez être dans la même ville et vous devez tous 
            les deux être en accord pour faire cette action. 
            Si le joueur qui reçoit la carte a maintenant plus de 7 cartes, il doit 
            immédiatement défausser une carte ou jouer un Évènement (cf. page 7).";

            Descriptions[ressource.Action_DiscoverCure] = @"Sur n’importe quelle station de recherche, défaussez 5 cartes Ville de la 
            même couleur pour découvrir le remède contre la maladie de cette couleur. 
            Déplacez le marqueur Remède sur son indicateur de remède découvert. 
            Cette maladie est maintenant guérie.
            Si aucun cube de cette couleur ne se trouve sur le plateau, cette maladie est 
            désormais éradiquée. Retournez son marqueur Remède du côté";

            Descriptions[ressource.Action_NextTurn] = @"Fin du tour";


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

        [CascadingParameter]
        IDebuggableUI DebugPanel { get; set; }

        void DebugSwitchAction()
        {
            Visible = !visible;
        }
        protected override void OnParametersSet()
        {
            if (DebugPanel != null)
                DebugPanel.AddDebugAction("Switch Actions", DebugSwitchAction);
            base.OnInitialized();
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

    }
}
