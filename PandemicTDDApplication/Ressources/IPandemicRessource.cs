using PandemicTDD;

namespace PandemicTDDApplication
{
    public interface IPandemicRessource
    {
        string EnterPlayerNumber { get; }
        string InvalidPlayersNumber { get; }
        string ActionNotPermitted { get; }
        string GameInitialization { get; }
        string ChooseLevel { get; }
        string Action_DriveFerry { get; }
        string Action_DirectFlight { get; }
        string Action_BuildStation { get; }
        string Action_TreatDisease { get; }
        string Action_ShareKnowledge { get; }
        string Action_DiscoverCure { get; }
        string Action_ShuttleFlight { get; }
        string Action_CharterFlight { get; }
        string Action_NextTurn { get; }
        string Action_PlayCardFromSpecialSlot { get; }

        string EnterPlayerName(int currentPlayer);
        string InvalidPlayerName(string playerName);
        string PlayerYourTurn(Player player);
        string ActionsRemains(int actionsRemaining);
    }

}
