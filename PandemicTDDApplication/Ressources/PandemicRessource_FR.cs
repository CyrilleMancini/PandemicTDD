using PandemicTDD;

namespace PandemicTDDApplication
{
    public class PandemicRessource_FR : IPandemicRessource
    {
        public string EnterPlayerNumber => "Combien de joueurs [2 - 4] ?";

        public string InvalidPlayersNumber => "Le nombre de joueurs doit être compris entre 2 et 4.";

        public string ActionNotPermitted => "Cette action n'est pas autorisée à cette étape.";

        public string GameInitialization => "Initialisation de la partie.";

        public string ChooseLevel => "Choisir le niveau de difficulté 1:Découverte, 2:Standard, 3:Héroïque";

        public string Action_DriveFerry => "Voiture / Transbordeur";
        public string Action_DirectFlight => "Vol Direct";
        public string Action_CharterFlight => "Vol Charter";
        public string Action_ShuttleFlight => "Navette";

        public string Action_BuildStation => "Construire une station de recherche";
        public string Action_TreatDisease => "Traiter une maladie";
        public string Action_ShareKnowledge => "Partager des connaissances";
        public string Action_DiscoverCure => "Découvrir un remède";

        public string Action_NextTurn => "Fin du tour";

        public string Action_PlayCardFromSpecialSlot => "Jouer la carte du slot spécial";

        public string ActionsRemains(int actionsRemaining)
        {
            return $"Il vous reste {actionsRemaining} actions à jouer.";
        }

        public string EnterPlayerName(int currentPlayer)
        {
            return $"Entrez le nom du joueur : {currentPlayer}";
        }

        public string InvalidPlayerName(string playerName)
        {
            return $"Nom du joueur invalide :{playerName}";
        }

        public string PlayerYourTurn(Player player)
        {            
            return $"{player.Role.Name} {player.Name} situé à {player.Town.Name} {player.Town.Country}, à vous de jouer.";
        }
    }
}
