using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{

    public class TownsInitializer
    {
        public static string Mumbai = "Mumbai";
        public static string Delhi = "Delhi";
        public static string Chennai = "Chennai";
        public static string Calcutta = "Calcutta";
        public static string Alger = "Alger";
        public static string Karachi = "Karachi";
        public static string Bagdad = "Bagdad";
        public static string Téhéran = "Téhéran";
        public static string Riyad = "Riyad";
        public static string Moscou = "Moscou";
        public static string Istanbul = "Istanbul";
        public static string San_Francisco = "San Francisco";
        public static string New_York = "New York";
        public static string Washington = "Washington";
        public static string Londres = "Londres";
        public static string Essen = "Essen";
        public static string Paris = "Paris";
        public static string Atlanta = "Atlanta";
        public static string Madrid = "Madrid";
        public static string Saint_Petersbourg = "Saint-Pétersbourg";
        public static string Chicago = "Chicago";
        public static string Montréal = "Montréal";
        public static string Milan = "Milan";
        public static string Pékin = "Pékin";
        public static string Sydney = "Sydney";
        public static string Séoul = "Séoul";
        public static string Shanghai = "Shanghai";
        public static string Osaka = "Osaka";
        public static string Taipei = "Taipei";
        public static string Tokyo = "Tokyo";
        public static string Ho_Chi_Minh_Ville = "Ho-Chi-Minh-Ville";
        public static string Bangkok = "Bangkok";
        public static string Hong_Kong = "Hong Kong";
        public static string Jakarta = "Jakarta";
        public static string Manille = "Manille";
        public static string Lagos = "Lagos";
        public static string Kinshasa = "Kinshasa";
        public static string Le_Caire = "Le Caire";
        public static string Mexico = "Mexico";
        public static string Lima = "Lima";
        public static string Miami = "Miami";
        public static string Los_Angeles = "Los Angeles";
        public static string Santiago = "Santiago";
        public static string Sao_Paulo = "Sao Paulo";
        public static string Johannesbourg = "Johannesbourg";
        public static string Khartoum = "Khartoum";
        public static string Bogota = "Bogota";
        public static string Buenos_Aires = "Buenos Aires";

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
                new Town(DiseaseColor.Yellow , Le_Caire, "Egypte"),
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
    }
}
