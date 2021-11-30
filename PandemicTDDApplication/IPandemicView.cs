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
        string AskDestinationAmong(Town[] Destinations);
        void DisplayLocation(Town town);
        void DisplayBoard(Board board);
        void DisplayPlayer(Player current);
        DiseaseColor AskDiseaseColor();
    }
}
