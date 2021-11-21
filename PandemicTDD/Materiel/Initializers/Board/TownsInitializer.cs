using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{

    public class TownsInitializer
    {
        public const string Mumbai = "Mumbai";
        public const string Delhi = "Delhi";
        public const string Chennai = "Chennai";
        public const string Calcutta = "Calcutta";
        public const string Alger = "Alger";
        public const string Karachi = "Karachi";
        public const string Bagdad = "Bagdad";
        public const string Téhéran = "Téhéran";
        public const string Riyad = "Riyad";
        public const string Moscou = "Moscou";
        public const string Istanbul = "Istanbul";
        public const string San_Francisco = "San Francisco";
        public const string New_York = "New York";
        public const string Washington = "Washington";
        public const string Londres = "Londres";
        public const string Essen = "Essen";
        public const string Paris = "Paris";
        public const string Atlanta = "Atlanta";
        public const string Madrid = "Madrid";
        public const string Saint_Petersbourg = "Saint-Pétersbourg";
        public const string Chicago = "Chicago";
        public const string Montréal = "Montréal";
        public const string Milan = "Milan";
        public const string Pékin = "Pékin";
        public const string Sydney = "Sydney";
        public const string Séoul = "Séoul";
        public const string Shanghai = "Shanghai";
        public const string Osaka = "Osaka";
        public const string Taipei = "Taipei";
        public const string Tokyo = "Tokyo";
        public const string Ho_Chi_Minh_Ville = "Ho-Chi-Minh-Ville";
        public const string Bangkok = "Bangkok";
        public const string Hong_Kong = "Hong Kong";
        public const string Jakarta = "Jakarta";
        public const string Manille = "Manille";
        public const string Lagos = "Lagos";
        public const string Kinshasa = "Kinshasa";
        public const string Le_Caire = "Le Caire";
        public const string Mexico = "Mexico";
        public const string Lima = "Lima";
        public const string Miami = "Miami";
        public const string Los_Angeles = "Los Angeles";
        public const string Santiago = "Santiago";
        public const string Sao_Paulo = "Sao Paulo";
        public const string Johannesbourg = "Johannesbourg";
        public const string Khartoum = "Khartoum";
        public const string Bogota = "Bogota";
        public const string Buenos_Aires = "Buenos Aires";

        static List<Town> Towns = null;

        internal List<Town> GetTowns()
        {
            if (Towns == null)
                Towns = new List<Town>() {
                new Town(DiseaseColor.Black, Mumbai, "Inde"),
                new Town(DiseaseColor.Black, Delhi, "Inde"),
                new Town(DiseaseColor.Black, Chennai, "Inde"),
                new Town(DiseaseColor.Black, Calcutta, "Inde"),
                new Town(DiseaseColor.Black, Alger, "Algérie"),
                new Town(DiseaseColor.Black, Karachi, "Pakistan"),
                new Town(DiseaseColor.Black, Bagdad, "Irak"),
                new Town(DiseaseColor.Black, Téhéran, "Iran"),
                new Town(DiseaseColor.Black , Le_Caire, "Egypte"),
                new Town(DiseaseColor.Black, Riyad, "Arabie Saoudite"),
                new Town(DiseaseColor.Black, Moscou, "Russie"),
                new Town(DiseaseColor.Black, Istanbul, "Turquie"),
                new Town(DiseaseColor.Blue, San_Francisco, "Etats-Unis"),
                new Town(DiseaseColor.Blue, New_York, "Etats-Unis"),
                new Town(DiseaseColor.Blue, Washington, "Etats-Unis"),
                new Town(DiseaseColor.Blue, Londres, "Angleterre"),
                new Town(DiseaseColor.Blue, Essen, "Allemagne"),
                new Town(DiseaseColor.Blue, Paris, "France"),
                new Town(DiseaseColor.Blue, Atlanta, "Etats-Unis"),
                new Town(DiseaseColor.Blue, Madrid, "Espagne"),
                new Town(DiseaseColor.Blue, Saint_Petersbourg, "Russie"),
                new Town(DiseaseColor.Blue, Chicago, "Etats-Unis"),
                new Town(DiseaseColor.Blue, Montréal, "Canada"),
                new Town(DiseaseColor.Blue, Milan, "Italie"),
                new Town(DiseaseColor.Red, Pékin, "République Populaire de Chine"),
                new Town(DiseaseColor.Red, Sydney, "Australie"),
                new Town(DiseaseColor.Red, Séoul, "Corée du Sud"),
                new Town(DiseaseColor.Red, Shanghai, "République Populaire de Chine"),
                new Town(DiseaseColor.Red, Osaka, "Japon"),
                new Town(DiseaseColor.Red, Taipei, "Tawain"),
                new Town(DiseaseColor.Red, Tokyo, "Japon"),
                new Town(DiseaseColor.Red, Ho_Chi_Minh_Ville, "Viet Nam"),
                new Town(DiseaseColor.Red, Bangkok, "Thailande"),
                new Town(DiseaseColor.Red, Hong_Kong, "République Populaire de Chine"),
                new Town(DiseaseColor.Red, Jakarta, "Indonésie"),
                new Town(DiseaseColor.Red, Manille, "Philippines"),
                new Town(DiseaseColor.Yellow , Lagos, "Nigeria"),
                new Town(DiseaseColor.Yellow , Kinshasa, "République Démocratique du Congo"),
                new Town(DiseaseColor.Yellow , Mexico, "Mexique "),
                new Town(DiseaseColor.Yellow , Lima, "Pérou"),
                new Town(DiseaseColor.Yellow , Miami, "Etats-Unis"),
                new Town(DiseaseColor.Yellow , Los_Angeles, "Etats-Unis"),
                new Town(DiseaseColor.Yellow , Santiago, "Chili"),
                new Town(DiseaseColor.Yellow , Sao_Paulo, "Brésil"),
                new Town(DiseaseColor.Yellow , Johannesbourg, "Afrique du Sud"),
                new Town(DiseaseColor.Yellow , Khartoum, "Soudan"),
                new Town(DiseaseColor.Yellow , Bogota, "Colombie"),
                new Town(DiseaseColor.Yellow , Buenos_Aires, "Pérou"),
            };

            return Towns;

        }

        internal void Reset()
        {
            if (Towns == null) return;
            Towns.ForEach(t => t.ControlDiseaseCenter = null);

        }



    }
}
