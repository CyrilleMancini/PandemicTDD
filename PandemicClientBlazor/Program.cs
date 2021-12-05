using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDD.Ressources;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PandemicClientBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            builder.Services.AddScoped<ResilientPopulationEventCard>();
            builder.Services.AddScoped<CalmNigthEventCard>();
            builder.Services.AddScoped<ForcastEventCard>();
            builder.Services.AddScoped<PublicSubventionEventCard>();
            builder.Services.AddScoped<AirLiftEventCard>();


            builder.Services.AddScoped<DiseaseBagsInitializer>();
            builder.Services.AddScoped<RoleCardInitializer>();
            builder.Services.AddScoped<SpreadCardInitializer>();
            builder.Services.AddScoped<TownsInitializer>();
            builder.Services.AddScoped<PlayerCardInitializer>();
            builder.Services.AddScoped<TownSlotsInitializer>();
            builder.Services.AddScoped<TownLinksInitializer>();
            builder.Services.AddScoped<GameInitializer>();
            builder.Services.AddScoped<GameBox>();
            //GameBox.Reset();
            //GameBox.GetBoard();
            builder.Services.AddScoped<GameState>();
            //GameState.RegisterObserver(ConsoleObserver);

            builder.Services.AddScoped<IPandemicRessource, PandemicRessource_FR>();


            await builder.Build().RunAsync();
        }
    }
}
