using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializer.SpreadInitRules
{
    internal class DrawNSpreadCardsAndAddNDiseasesOnIt
    {
        public DrawNSpreadCardsAndAddNDiseasesOnIt()
        {
        }

        internal void ExecuteRule(int nbDiseases, GameBox gamebox)
        {
            for (int i = 0; i < 3; i++)
            {
                SpreadCard card = gamebox.GetBoard().SpreadStack.Pop();
                List<DiseaseCube> cubes = gamebox.GetDiseaseBags().GetCubes(card.Town.Color, nbDiseases);
                card.Town.AddDisease(cubes);
                gamebox.GetBoard().SpreadDiscardStack.Push(card);
            }
        }
    }
}