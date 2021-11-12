using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializer.SpreadInitRules
{
    internal class Draw3SpreadCardAndAdd3DiseasesOnIt
    {
        public Draw3SpreadCardAndAdd3DiseasesOnIt()
        {
        }

        internal void ExecuteRule(GameBox gamebox)
        {
            for (int i = 0; i < 3; i++)
            {
                SpreadCard card = gamebox.GetBoard().SpreadStack.Pop();
                List<DiseaseCube> cubes = gamebox.GetDiseaseBags().GetCubes(card.Town.Color, 3);
                card.Town.AddDisease(cubes);
                gamebox.GetBoard().SpreadDiscardStack.Push(card);
            }
        }
    }
}