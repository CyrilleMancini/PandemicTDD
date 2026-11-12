using Microsoft.AspNetCore.Components;
using PandemicTDD;

namespace PandemicClientBlazor.Pages;

public partial class TownsView
{

    public TownPositions position { get; set; } = new TownPositions();

    [Parameter]
    public GameState GameState { get; set; }

}
