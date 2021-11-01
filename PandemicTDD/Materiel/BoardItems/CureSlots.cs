using System;

namespace PandemicTDD.Materiel
{

    public enum DiseaseStatus
    {
        None,
        Treated,
        Eradicated
    }

    public class CureSlots
    {

        public DiseaseStatus BlackSlot { get; private set; } = DiseaseStatus.None;
        public DiseaseStatus BlueSlot { get; private set; } = DiseaseStatus.None;
        public DiseaseStatus RedSlot { get; private set; } = DiseaseStatus.None;
        public DiseaseStatus YellowSlot { get; private set; } = DiseaseStatus.None;


        public void Reset()
        {
            BlackSlot = DiseaseStatus.None;
            BlueSlot = DiseaseStatus.None;
            RedSlot = DiseaseStatus.None;
            YellowSlot = DiseaseStatus.None;
        }
    }
}