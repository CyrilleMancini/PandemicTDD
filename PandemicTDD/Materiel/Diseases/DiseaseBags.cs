using PandemicTDD.Events;
using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class DiseaseBags
    {

        public List<DiseaseCube> Blacks = new();

        public List<DiseaseCube> Reds = new();

        public List<DiseaseCube> Yellows = new();

        public List<DiseaseCube> Blues = new();

        public List<DiseaseCube> GetCubes(DiseaseColor color, int number)
        {
            if (number <= 0) throw new ArgumentException($"Bad Quantity {{number}}");
            
            List<DiseaseCube> cubes;
            
            switch (color)
            {
                case DiseaseColor.Black:
                    if (Blacks.Count < number) throw new YouLooseException("Not enough Black Disease, You Lose.");
                    cubes = Blacks.GetRange(0, number);
                    Blacks.RemoveRange(0, number);
                    break;
                case DiseaseColor.Red:
                    if (Reds.Count < number) throw new YouLooseException("Not enough Red Disease, You Lose.");
                    cubes = Reds.GetRange(0, number);
                    Reds.RemoveRange(0, number);
                    break;
                case DiseaseColor.Yellow:
                    if (Yellows.Count < number) throw new YouLooseException("Not enough Yellow Disease, You Lose.");
                    cubes = Yellows.GetRange(0, number);
                    Yellows.RemoveRange(0, number);
                    break;
                case DiseaseColor.Blue:
                    if (Blues.Count < number) throw new YouLooseException("Not enough Blue Disease, You Lose.");
                    cubes = Blues.GetRange(0, number);
                    Blues.RemoveRange(0, number);
                    break;
                default:
                    throw new ArgumentException("Unexpected Exception");
            }
            return cubes;
        }

    }
}