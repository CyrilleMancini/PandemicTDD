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
        string AskDestinationAmong(string[] Destination);
        void DisplayLocation(Town town);
    }
}
