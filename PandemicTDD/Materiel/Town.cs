using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{
    public class Town
    {
        private readonly List<DiseaseCube> DiseaseCubes = new();

        public DiseaseColor Color { get; }

        public string Name { get; }

        public string Country { get; }

        public Town(DiseaseColor color, string name, string pays)
        {
            Color = color;
            Name = name;
            Country = pays;
        }

        internal void ResetDiseases()
        {
            DiseaseCubes.Clear();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal void AddDisease(List<DiseaseCube> cubes)
        {
            DiseaseCubes.AddRange(cubes);
        }

        public static bool operator ==(Town t1, Town t2)
        {
            if (t1 is null && t2 is null) return true;

            return t1.Equals(t2);
        }
        public static bool operator !=(Town t1, Town t2)
        {
            if (t1 == null && t2 == null) return false;

            return !t1.Equals(t2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Town t)
                return t.Name == Name && t.Color == Color && t.Country == Country;

            return false;
        }

        internal List<DiseaseCube> GetDiseaseByColor(DiseaseColor color)
        {
            return DiseaseCubes
                .Where(c => c.Color == color)
                .ToList();
        }

        internal void TreatOneCubeDisease(DiseaseColor color)
        {
            var toTreat = GetDiseaseByColor(color);
            if (toTreat.Count == 0)
                throw new ArgumentException($"No more {color} disease to treat in that town.");

            DiseaseCubes.Remove(toTreat[0]);
        }

        public override string ToString()
        {
            return $"{Color} {Name} {Country} {DiseaseCubes.Count} ";
        }
    }
}