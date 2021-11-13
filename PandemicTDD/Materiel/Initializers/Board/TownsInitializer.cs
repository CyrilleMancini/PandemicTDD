using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{

    public class TownsInitializer
    {
        public static String Mumbai = "Mumbai";
        public static String Delhi = "Delhi";
        public static String Chennai = "Chennai";
        public static String Calcutta = "Calcutta";
        public static String Alger = "Alger";
        public static String Karachi = "Karachi";
        public static String Bagdad = "Bagdad";
        public static String Téhéran = "Téhéran";
        public static String Riyad = "Riyad";
        public static String Moscou = "Moscou";
        public static String Istanbul = "Istanbul";
        public static String San_Francisco = "San Francisco";
        public static String New_York = "New York";
        public static String Washington = "Washington";
        public static String Londres = "Londres";
        public static String Essen = "Essen";
        public static String Paris = "Paris";
        public static String Atlanta = "Atlanta";
        public static String Madrid = "Madrid";
        public static String Saint_Petersbourg = "Saint-Pétersbourg";
        public static String Chicago = "Chicago";
        public static String Montréal = "Montréal";
        public static String Milan = "Milan";
        public static String Pékin = "Pékin";
        public static String Sydney = "Sydney";
        public static String Séoul = "Séoul";
        public static String Shanghai = "Shanghai";
        public static String Osaka = "Osaka";
        public static String Taipei = "Taipei";
        public static String Tokyo = "Tokyo";
        public static String Ho_Chi_Minh_Ville = "Ho-Chi-Minh-Ville";
        public static String Bangkok = "Bangkok";
        public static String Hong_Kong = "Hong Kong";
        public static String Jakarta = "Jakarta";
        public static String Manille = "Manille";
        public static String Lagos = "Lagos";
        public static String Kinshasa = "Kinshasa";
        public static String Le_Caire = "Le Caire";
        public static String Mexico = "Mexico";
        public static String Lima = "Lima";
        public static String Miami = "Miami";
        public static String Los_Angeles = "Los Angeles";
        public static String Santiago = "Santiago";
        public static String Sao_Paulo = "Sao Paulo";
        public static String Johannesbourg = "Johannesbourg";
        public static String Khartoum = "Khartoum";
        public static String Bogota = "Bogota";
        public static String Buenos_Aires = "Buenos Aires";

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
