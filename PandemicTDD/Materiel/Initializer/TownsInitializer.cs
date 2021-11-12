using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializer
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
                new Town("Noir", Mumbai, "Inde"),
                new Town("Noir", Delhi, "Inde"),
                new Town("Noir", Chennai, "Inde"),
                new Town("Noir", Calcutta, "Inde"),
                new Town("Noir", Alger, "Algérie"),
                new Town("Noir", Karachi, "Pakistan"),
                new Town("Noir", Bagdad, "Irak"),
                new Town("Noir", Téhéran, "Iran"),
                new Town("Noir", Riyad, "Arabie Saoudite"),
                new Town("Noir", Moscou, "Russie"),
                new Town("Noir", Istanbul, "Turquie"),
                new Town("Bleu", San_Francisco, "Etats-Unis"),
                new Town("Bleu", New_York, "Etats-Unis"),
                new Town("Bleu", Washington, "Etats-Unis"),
                new Town("Bleu", Londres, "Angleterre"),
                new Town("Bleu", Essen, "Allemagne"),
                new Town("Bleu", Paris, "France"),
                new Town("Bleu", Atlanta, "Etats-Unis"),
                new Town("Bleu", Madrid, "Espagne"),
                new Town("Bleu", Saint_Petersbourg, "Russie"),
                new Town("Bleu", Chicago, "Etats-Unis"),
                new Town("Bleu", Montréal, "Canada"),
                new Town("Bleu", Milan, "Italie"),
                new Town("Rouge", Pékin, "République Populaire de Chine"),
                new Town("Rouge", Sydney, "Australie"),
                new Town("Rouge", Séoul, "Corée du Sud"),
                new Town("Rouge", Shanghai, "République Populaire de Chine"),
                new Town("Rouge", Osaka, "Japon"),
                new Town("Rouge", Taipei, "Tawain"),
                new Town("Rouge", Tokyo, "Japon"),
                new Town("Rouge", Ho_Chi_Minh_Ville, "Viet Nam"),
                new Town("Rouge", Bangkok, "Thailande"),
                new Town("Rouge", Hong_Kong, "République Populaire de Chine"),
                new Town("Rouge", Jakarta, "Indonésie"),
                new Town("Rouge", Manille, "Philippines"),
                new Town("Jaune", Lagos, "Nigeria"),
                new Town("Jaune", Kinshasa, "République Démocratique du Congo"),
                new Town("Jaune", Le_Caire, "Egypte"),
                new Town("Jaune", Mexico, "Mexique "),
                new Town("Jaune", Lima, "Pérou"),
                new Town("Jaune", Miami, "Etats-Unis"),
                new Town("Jaune", Los_Angeles, "Etats-Unis"),
                new Town("Jaune", Santiago, "Chili"),
                new Town("Jaune", Sao_Paulo, "Brésil"),
                new Town("Jaune", Johannesbourg, "Afrique du Sud"),
                new Town("Jaune", Khartoum, "Soudan"),
                new Town("Jaune", Bogota, "Colombie"),
                new Town("Jaune", Buenos_Aires, "Pérou"),
            };

            return Towns;

        }
    }
}
