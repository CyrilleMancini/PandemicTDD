using PandemicTDD.Materiel.Initializers;
using System.Collections.Generic;

namespace PandemicClientBlazor.Pages;


public class UiTownItem
{
    public UiTownItem(int x, int y, int labelOffsetX, int labelOffsetY)
    {
        X = x;
        Y = y;
        LabelOffsetX = labelOffsetX;
        LabelOffsetY = labelOffsetY;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public int LabelOffsetX { get; set; }
    public int LabelOffsetY { get; set; }

    public int LabelX => X + LabelOffsetX;
    public int LabelY => Y + LabelOffsetY;

}

public class TownPositions
{
    public TownPositions()
    {

    }

    public Dictionary<string, UiTownItem> Positions = new()
    {
        {TownsInitializer.Alger, new UiTownItem(809,430,-24,20)},
        {TownsInitializer.Atlanta, new UiTownItem(396,446,-20,16)},
        {TownsInitializer.Bagdad, new UiTownItem(1005,448,-20,16)},
        {TownsInitializer.Bangkok, new UiTownItem(1272,548,-20,16)},
        {TownsInitializer.Bogota, new UiTownItem(442,594,-20,16)},
        {TownsInitializer.Buenos_Aires, new UiTownItem(520,790,-20,16)},
        {TownsInitializer.Calcutta, new UiTownItem(1212,506,-20,16)},
        {TownsInitializer.Chennai, new UiTownItem(1174,551,-20,16)},
        {TownsInitializer.Chicago, new UiTownItem(380,397,-20,16)},
        {TownsInitializer.Delhi, new UiTownItem(1160,474,-20,16)},
        {TownsInitializer.Essen, new UiTownItem(829,329,-20,16)},
        {TownsInitializer.Ho_Chi_Minh_Ville, new UiTownItem(1302,565,-20,16)},
        {TownsInitializer.Hong_Kong, new UiTownItem(1335,505,-20,16)},
        {TownsInitializer.Istanbul, new UiTownItem(931,401,-20,16)},
        {TownsInitializer.Jakarta, new UiTownItem(1301,643,-20,16)},
        {TownsInitializer.Johannesbourg, new UiTownItem(928,746,-20,16)},
        {TownsInitializer.Karachi, new UiTownItem(1112,496,-20,16)},
        {TownsInitializer.Khartoum, new UiTownItem(951,540,-20,16)},
        {TownsInitializer.Kinshasa, new UiTownItem(868,637,-20,16)},
        {TownsInitializer.Lagos, new UiTownItem(811,585,-20,16)},
        {TownsInitializer.Le_Caire, new UiTownItem(942,468,-20,16)},
        {TownsInitializer.Lima, new UiTownItem(432,677,-20,16)},
        {TownsInitializer.Londres, new UiTownItem(794,330,-20,16)},
        {TownsInitializer.Los_Angeles, new UiTownItem(237,444,-20,16)},
        {TownsInitializer.Madrid, new UiTownItem(776,406,-20,16)},
        {TownsInitializer.Manille, new UiTownItem(1369,543,-20,16)},
        {TownsInitializer.Mexico, new UiTownItem(326,520,-20,16)},
        {TownsInitializer.Miami, new UiTownItem(414,488,-20,16)},
        {TownsInitializer.Milan, new UiTownItem(839,371,-20,16)},
        {TownsInitializer.Montréal, new UiTownItem(445,369,-20,16)},
        {TownsInitializer.Moscou, new UiTownItem(975,296,-20,16)},
        {TownsInitializer.Mumbai, new UiTownItem(1141,523,-20,16) },
        {TownsInitializer.New_York, new UiTownItem(443,403,-20,16)},
        {TownsInitializer.Osaka, new UiTownItem(1435,440,-20,16)},
        {TownsInitializer.Paris, new UiTownItem(806,347,-20,16)},
        {TownsInitializer.Pékin, new UiTownItem(1347,407,-20,16)},
        {TownsInitializer.Riyad, new UiTownItem(1015,497,-20,16)},
        {TownsInitializer.Saint_Petersbourg, new UiTownItem(938,256,-20,16)},
        {TownsInitializer.San_Francisco, new UiTownItem(213,422,-120,0)},
        {TownsInitializer.Santiago, new UiTownItem(461,783,-20,16)},
        {TownsInitializer.Sao_Paulo, new UiTownItem(574,734,-20,16)},
        {TownsInitializer.Shanghai, new UiTownItem(1371,461,-20,16)},
        {TownsInitializer.Sydney, new UiTownItem(1514,783,-20,16)},
        {TownsInitializer.Séoul, new UiTownItem(1395,422,-20,16)},
        {TownsInitializer.Taipei, new UiTownItem(1371,494,-20,16)},
        {TownsInitializer.Tokyo, new UiTownItem(1457,432,-20,16)},
        {TownsInitializer.Téhéran, new UiTownItem(1039,436,-20,16)},
        {TownsInitializer.Washington, new UiTownItem(428,413,-20,16)},
    };



}
