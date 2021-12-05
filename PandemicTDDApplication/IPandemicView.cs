using PandemicTDD;
using PandemicTDD.Materiel;
using System;

namespace PandemicTDDApplication
{
    public interface IPandemicView
    {
        void DisplayInstruction(string instruction);
        void AddPlayerAction(string ActionName, Action action);
        void DisplayActions();
        void AskAction();
        void AskDestinationAmong(Town[] Destinations, IWaitDestinationDelegate DestinationUser);
        void DisplayLocation(Town town);
        void DisplayBoard(Board board);
        void DisplayPlayer(Player current);
        void AskDiseaseColor(IWaitForColor ColorUser);
    }

    public delegate void IWaitDestinationDelegate(String Destination);
    public delegate void IWaitForColor(DiseaseColor Color);
}
