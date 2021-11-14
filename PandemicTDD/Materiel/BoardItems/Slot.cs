namespace PandemicTDD.Materiel
{


    public class Slot
    {

        public DiseaseStatus Status { get; private set; } = DiseaseStatus.None;

        public Slot(DiseaseStatus status)
        {
            Status = status;
        }

        internal void Reset()
        {
            Status = DiseaseStatus.None;
        }

        internal void Next()
        {
            switch (Status)
            {
                case DiseaseStatus.None:
                    Status = DiseaseStatus.Treated;
                    break;
                case DiseaseStatus.Treated:
                    Status = DiseaseStatus.Eradicated;
                    break;
                case DiseaseStatus.Eradicated:
                    break;
                default:
                    break;
            }
        }
    }
}