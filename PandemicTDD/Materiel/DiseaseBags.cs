using System;
using System.Collections.Generic;
using System.Drawing;

namespace PandemicTDD.Materiel
{

    public enum DiseaseColor
    {
        Black,
        Red,
        Yellow,
        Blue
    }


    public class DiseaseBags
    {

        public List<DiseaseCube> Blacks = new List<DiseaseCube>();

        public List<DiseaseCube> Reds = new List<DiseaseCube>();

        public List<DiseaseCube> Yellows = new List<DiseaseCube>();

        public List<DiseaseCube> Blues = new List<DiseaseCube>();

        public List<DiseaseCube> GetCubes(DiseaseColor color, int number)
        {
            List<DiseaseCube> cubes;
            switch (color)
            {
                case DiseaseColor.Black:
                    cubes = Blacks.GetRange(0, number);
                    Blacks.RemoveRange(0, number);
                    break;
                case DiseaseColor.Red:
                    cubes = Reds.GetRange(0, number);
                    Reds.RemoveRange(0, number);
                    break;
                case DiseaseColor.Yellow:
                    cubes = Yellows.GetRange(0, number);
                    Yellows.RemoveRange(0, number);
                    break;
                case DiseaseColor.Blue:
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