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



    }
}