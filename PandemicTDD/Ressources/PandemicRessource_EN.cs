using PandemicTDD;

namespace PandemicTDD.Ressources
{
    public class PandemicRessource_EN : IPandemicRessource
    {
        public string EnterPlayerNumber => "How many players [2 - 4] ?";

        public string InvalidPlayersNumber => "Player number must be between 2 and 4.";

        public string ActionNotPermitted => throw new System.NotImplementedException();

        public string GameInitialization => throw new System.NotImplementedException();

        public string ChooseLevel => throw new System.NotImplementedException();

        public string Action_DriveFerry => throw new System.NotImplementedException();

        public string Action_DirectFlight => throw new System.NotImplementedException();

        public string Action_BuildStation => throw new System.NotImplementedException();

        public string Action_TreatDisease => throw new System.NotImplementedException();

        public string Action_ShareKnowledge => throw new System.NotImplementedException();

        public string Action_DiscoverCure => throw new System.NotImplementedException();

        public string Action_ShuttleFlight => throw new System.NotImplementedException();

        public string Action_CharterFlight => throw new System.NotImplementedException();

        public string Action_NextTurn => throw new System.NotImplementedException();

        public string Action_PlayCardFromSpecialSlot => throw new System.NotImplementedException();

        public string AirLiftEventName => throw new System.NotImplementedException();

        public string AirLiftEventDescription => throw new System.NotImplementedException();

        public string PublicSubventionEventDescription => throw new System.NotImplementedException();

        public string PublicSubventionEventName => throw new System.NotImplementedException();

        public string ForcastEventDescription => throw new System.NotImplementedException();

        public string ForcastEventName => throw new System.NotImplementedException();

        public string CalmNigthEventDescription => throw new System.NotImplementedException();

        public string CalmNigthEventName => throw new System.NotImplementedException();

        public string ResilientPopulationEventName => throw new System.NotImplementedException();

        public string ResilientPopulationEventDescription => throw new System.NotImplementedException();

        public string ActionsRemains(int actionsRemaining)
        {
            throw new System.NotImplementedException();
        }

        public string EnterPlayerName(int currentPlayer)
        {
            throw new System.NotImplementedException();
        }

        public string InvalidPlayerName(string playerName)
        {
            throw new System.NotImplementedException();
        }

        public string PlayerYourTurn(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
