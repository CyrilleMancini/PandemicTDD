using PandemicTDD.Materiel.BoardItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PandemicTDDTests")]
namespace PandemicTDD.Materiel.Initializers
{
    public class TownSlotsInitializer
    {
        private readonly TownsInitializer TownInitializer;

        public TownSlotsInitializer(TownsInitializer townsInitializer)
        {
            this.TownInitializer = townsInitializer;
            InitTownSlots();
        }

        public List<TownSlot> TownSlots { get; private set; }

        private void InitTownSlots()
        {
            if (TownSlots == null)
            {
                TownSlots = new List<TownSlot>();
                foreach (Town town in TownInitializer.GetTowns())
                {
                    TownSlots.Add(new TownSlot(town));
                }

                foreach(TownsLink link in Links)
                {
                    Link2Towns(link);
                }
            }
        }

        internal void Link2Towns(TownsLink link)
        {
            TownSlot t1 = GetTownSlot(link.Town1);
            TownSlot t2 = GetTownSlot(link.Town2);
            t1.Links.Add(t2);
            t2.Links.Add(t1);
        }

        public TownSlot GetTownSlot(string townName)
        {
            try
            {
                TownSlot town = TownSlots.Single(it => it.Town.Name == townName);
                return town;
            }
            catch (InvalidOperationException Ex)
            {
                throw new UnkownTownException($"{townName} is unknown");
            }
        }

        private TownsLink[] Links = new TownsLink[] {
                    new TownsLink("Mumbai", "Chennai"),
                    new TownsLink("Mumbai", "Karachi"),
                    new TownsLink("Mumbai", "Delhi"),
                    new TownsLink("Chennai", "Delhi"),
                    new TownsLink("Chennai", "Calcutta"),
                    new TownsLink("Chennai", "Bangkok"),
                    new TownsLink("Chennai", "Jakarta"),
                    new TownsLink("Karachi", "Téhéran"),
                    new TownsLink("Karachi", "Bagdad"),
                    new TownsLink("Karachi", "Riyad"),
                    new TownsLink("Karachi", "Delhi"),
                    new TownsLink("Delhi", "Calcutta"),
                    new TownsLink("Delhi", "Téhéran"),
                    new TownsLink("Calcutta", "Hong Kong"),
                    new TownsLink("Calcutta", "Bangkok"),
                    new TownsLink("Bangkok", "Hong Kong"),
                    new TownsLink("Bangkok", "Ho-Chi-Minh-Ville"),
                    new TownsLink("Bangkok", "Jakarta"),
                    new TownsLink("Jakarta", "Ho-Chi-Minh-Ville"),
                    new TownsLink("Jakarta", "Sydney"),
                    new TownsLink("Téhéran", "Bagdad"),
                    new TownsLink("Téhéran", "Moscou"),
                    new TownsLink("Bagdad", "Istanbul"),
                    new TownsLink("Bagdad", "Le Caire"),
                    new TownsLink("Bagdad", "Riyad"),
                    new TownsLink("Riyad", "Le Caire"),
                    new TownsLink("Hong Kong", "Shanghai"),
                    new TownsLink("Hong Kong", "Taipei"),
                    new TownsLink("Hong Kong", "Manille"),
                    new TownsLink("Hong Kong", "Ho-Chi-Minh-Ville"),
                    new TownsLink("Ho-Chi-Minh-Ville", "Manille"),
                    new TownsLink("Sydney", "Los Angeles"),
                    new TownsLink("Sydney", "Manille"),
                    new TownsLink("Moscou", "Saint-Pétersbourg"),
                    new TownsLink("Moscou", "Istanbul"),
                    new TownsLink("Istanbul", "Saint-Pétersbourg"),
                    new TownsLink("Istanbul", "Milan"),
                    new TownsLink("Istanbul", "Alger"),
                    new TownsLink("Istanbul", "Le Caire"),
                    new TownsLink("Le Caire", "Alger"),
                    new TownsLink("Le Caire", "Khartoum"),
                    new TownsLink("Shanghai", "Pékin"),
                    new TownsLink("Shanghai", "Séoul"),
                    new TownsLink("Shanghai", "Tokyo"),
                    new TownsLink("Shanghai", "Taipei"),
                    new TownsLink("Taipei", "Manille"),
                    new TownsLink("Taipei", "Osaka"),
                    new TownsLink("Manille", "Sydney"),
                    new TownsLink("Manille", "San Francisco"),
                    new TownsLink("Los Angeles", "San Francisco"),
                    new TownsLink("Los Angeles", "Mexico"),
                    new TownsLink("Los Angeles", "Chicago"),
                    new TownsLink("Saint-Pétersbourg", "Essen"),
                    new TownsLink("Milan", "Essen"),
                    new TownsLink("Milan", "Paris"),
                    new TownsLink("Alger", "Madrid"),
                    new TownsLink("Alger", "Paris"),
                    new TownsLink("Khartoum", "Lagos"),
                    new TownsLink("Khartoum", "Kinshasa"),
                    new TownsLink("Khartoum", "Johannesbourg"),
                    new TownsLink("Pékin", "Séoul"),
                    new TownsLink("Séoul", "Tokyo"),
                    new TownsLink("Tokyo", "Osaka"),
                    new TownsLink("Tokyo", "San Francisco"),
                    new TownsLink("San Francisco", "Chicago"),
                    new TownsLink("Mexico", "Miami"),
                    new TownsLink("Mexico", "Bogota"),
                    new TownsLink("Mexico", "Lima"),
                    new TownsLink("Mexico", "Chicago"),
                    new TownsLink("Chicago", "Montréal"),
                    new TownsLink("Chicago", "Atlanta"),
                    new TownsLink("Essen", "Londres"),
                    new TownsLink("Essen", "Paris"),
                    new TownsLink("Paris", "Londres"),
                    new TownsLink("Paris", "Madrid"),
                    new TownsLink("Madrid", "Londres"),
                    new TownsLink("Madrid", "Sao Paulo"),
                    new TownsLink("Madrid", "New York"),
                    new TownsLink("Lagos", "Kinshasa"),
                    new TownsLink("Lagos", "Sao Paulo"),
                    new TownsLink("Kinshasa", "Johannesbourg"),
                    new TownsLink("Montréal", "New York"),
                    new TownsLink("Montréal", "Washington"),
                    new TownsLink("Atlanta", "Washington"),
                    new TownsLink("Atlanta", "Miami"),
                    new TownsLink("Londres", "New York"),
                    new TownsLink("Sao Paulo", "Buenos Aires"),
                    new TownsLink("Sao Paulo", "Bogota"),
                    new TownsLink("New York", "Washington"),
                    new TownsLink("Miami", "Bogota"),
                    new TownsLink("Bogota", "Lima"),
                    new TownsLink("Bogota", "Buenos Aires"),
                    new TownsLink("Lima", "Santiago"),
        };

    }
}
