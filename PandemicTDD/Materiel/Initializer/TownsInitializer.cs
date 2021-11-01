using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializer
{

    public class TownsInitializer
    {
        static List<Town> Towns = null;

        internal List<Town> GetTowns()
        {
            if (Towns == null)
                Towns = new List<Town>() {
                new Town("Noir", "Mumbai", "Inde"),
                new Town("Noir", "Delhi", "Inde"),
                new Town("Noir", "Chennai", "Inde"),
                new Town("Noir", "Calcutta", "Inde"),
                new Town("Noir", "Alger", "Algérie"),
                new Town("Noir", "Karachi", "Pakistan"),
                new Town("Noir", "Bagdad", "Irak"),
                new Town("Noir", "Téhéran", "Iran"),
                new Town("Noir", "Riyad", "Arabie Saoudite"),
                new Town("Noir", "Moscou", "Russie"),
                new Town("Noir", "Istanbul", "Turquie"),
                new Town("Bleu", "San Francisco", "Etats-Unis"),
                new Town("Bleu", "New York", "Etats-Unis"),
                new Town("Bleu", "Washington", "Etats-Unis"),
                new Town("Bleu", "Londres", "Angleterre"),
                new Town("Bleu", "Essen", "Allemagne"),
                new Town("Bleu", "Paris", "France"),
                new Town("Bleu", "Atlanta", "Etats-Unis"),
                new Town("Bleu", "Madrid", "Espagne"),
                new Town("Bleu", "Saint-Pétersbourg", "Russie"),
                new Town("Bleu", "Chicago", "Etats-Unis"),
                new Town("Bleu", "Montréal", "Canada"),
                new Town("Bleu", "Milan", "Italie"),
                new Town("Rouge", "Pékin", "République Populaire de Chine"),
                new Town("Rouge", "Sydney", "Australie"),
                new Town("Rouge", "Séoul", "Corée du Sud"),
                new Town("Rouge", "Shanghai", "République Populaire de Chine"),
                new Town("Rouge", "Osaka", "Japon"),
                new Town("Rouge", "Tapei", "Tawain"),
                new Town("Rouge", "Tokyo", "Japon"),
                new Town("Rouge", "Ho-Chi-Minh-Ville", "Viet Nam"),
                new Town("Rouge", "Bangkok", "Thailande"),
                new Town("Rouge", "Honk Kong", "République Populaire de Chine"),
                new Town("Rouge", "Jakarta", "Indonésie"),
                new Town("Rouge", "Manille", "Philippines"),
                new Town("Jaune", "Lagos", "Nigeria"),
                new Town("Jaune", "Kinshasa", "République Démocratique du Congo"),
                new Town("Jaune", "Le Caire", "Egypte"),
                new Town("Jaune", "Mexico", "Mexique "),
                new Town("Jaune", "Lima", "Pérou"),
                new Town("Jaune", "Miami", "Etats-Unis"),
                new Town("Jaune", "Los Angeles", "Etats-Unis"),
                new Town("Jaune", "Santiago", "Chili"),
                new Town("Jaune", "Sao Paulo", "Brésil"),
                new Town("Jaune", "Johannesbourg", "Afrique du Sud"),
                new Town("Jaune", "Khartoum", "Soudan"),
                new Town("Jaune", "Bogota", "Colombie"),
                new Town("Jaune", "Buenos Aires", "Pérou"),
            };

            return Towns;

        }
    }
}
