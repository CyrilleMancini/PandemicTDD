using PandemicTDDTests.EndOfGame;
using System;

namespace PandemicTDD.Materiel
{


    public class CureSlots
    {
        public Slot BlackSlot { get; private set; } = new Slot(DiseaseStatus.None);

        public Slot BlueSlot { get; private set; } = new Slot(DiseaseStatus.None);

        public Slot RedSlot { get; private set; } = new Slot(DiseaseStatus.None);

        public Slot YellowSlot { get; private set; } = new Slot(DiseaseStatus.None);

        public void Reset()
        {
            BlackSlot.Reset();
            BlueSlot.Reset();
            RedSlot.Reset();
            YellowSlot.Reset();
        }

        internal void DiscoverCure(DiseaseColor disease)
        {
            switch (disease)
            {
                case DiseaseColor.Black when BlackSlot.Status == DiseaseStatus.None:
                    BlackSlot.Next();
                    break;

                case DiseaseColor.Red when RedSlot.Status == DiseaseStatus.None:
                    RedSlot.Next();
                    break;

                case DiseaseColor.Yellow when YellowSlot.Status == DiseaseStatus.None:
                    YellowSlot.Next();
                    break;

                case DiseaseColor.Blue when BlueSlot.Status == DiseaseStatus.None:
                    BlueSlot.Next();
                    break;
                default:
                    break;
            }

            if (BlackSlot.Status != DiseaseStatus.None
                && BlueSlot.Status != DiseaseStatus.None
                && RedSlot.Status != DiseaseStatus.None
                && YellowSlot.Status != DiseaseStatus.None)
                throw new VictoryAllCuresDiscoveredException();
        }
    }
}