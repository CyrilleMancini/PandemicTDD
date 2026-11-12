using Microsoft.AspNetCore.Components;
using PandemicTDD;
using PandemicTDD.Materiel.Initializers;
using System.Collections.Generic;
using System.Drawing;

namespace PandemicClientBlazor.Pages;

public partial class TownsView
{

    public TownPositions position { get; set; } = new TownPositions();

    [Parameter]
    public GameState GameState { get; set; }

}


public class TownPositions
{
    public TownPositions()
    {

    }

    public Dictionary<string, Point> Positions = new()
    {
        {TownsInitializer.Mumbai, new Point(1141,523) },
        {TownsInitializer.Delhi, new Point(1160,474)},
        {TownsInitializer.Chennai, new Point(1174,551)},
        {TownsInitializer.Calcutta, new Point(1212,506)},
        {TownsInitializer.Alger, new Point(809,430)},
        {TownsInitializer.Karachi, new Point(1112,496)},
        {TownsInitializer.Bagdad, new Point(1005,448)},
        {TownsInitializer.Téhéran, new Point(1039,436)},
        {TownsInitializer.Le_Caire, new Point(942,468)},
        {TownsInitializer.Riyad, new Point(1015,497)},
        {TownsInitializer.Moscou, new Point(975,296)},
        {TownsInitializer.Istanbul, new Point(931,401)},
        {TownsInitializer.San_Francisco, new Point(213,422)},
        {TownsInitializer.New_York, new Point(443,403)},
        {TownsInitializer.Washington, new Point(428,413)},
        {TownsInitializer.Londres, new Point(794,330)},
        {TownsInitializer.Essen, new Point(829,329)},
        {TownsInitializer.Paris, new Point(806,347)},
        {TownsInitializer.Atlanta, new Point(396,446)},
        {TownsInitializer.Madrid, new Point(776,406)},
        {TownsInitializer.Saint_Petersbourg, new Point(938,256)},
        {TownsInitializer.Chicago, new Point(380,397)},
        {TownsInitializer.Montréal, new Point(445,369)},
        {TownsInitializer.Milan, new Point(839,371)},
        {TownsInitializer.Pékin, new Point(1347,407)},
        {TownsInitializer.Sydney, new Point(1514,783)},
        {TownsInitializer.Séoul, new Point(1395,422)},
        {TownsInitializer.Shanghai, new Point(1371,461)},
        {TownsInitializer.Osaka, new Point(1435,440)},
        {TownsInitializer.Taipei, new Point(1371,494)},
        {TownsInitializer.Tokyo, new Point(1457,432)},
        {TownsInitializer.Ho_Chi_Minh_Ville, new Point(1302,565)},
        {TownsInitializer.Bangkok, new Point(1272,548)},
        {TownsInitializer.Hong_Kong, new Point(1335,505)},
        {TownsInitializer.Jakarta, new Point(1301,643)},
        {TownsInitializer.Manille, new Point(1369,543)},
        {TownsInitializer.Lagos, new Point(811,585)},
        {TownsInitializer.Kinshasa, new Point(868,637)},
        {TownsInitializer.Mexico, new Point(326,520)},
        {TownsInitializer.Lima, new Point(432,677)},
        {TownsInitializer.Miami, new Point(414,488)},
        {TownsInitializer.Los_Angeles, new Point(237,444)},
        {TownsInitializer.Santiago, new Point(461,783)},
        {TownsInitializer.Sao_Paulo, new Point(574,734)},
        {TownsInitializer.Johannesbourg, new Point(928,746)},
        {TownsInitializer.Khartoum, new Point(951,540)},
        {TownsInitializer.Bogota, new Point(442,594)},
        {TownsInitializer.Buenos_Aires, new Point(520,790)},
    };



}
