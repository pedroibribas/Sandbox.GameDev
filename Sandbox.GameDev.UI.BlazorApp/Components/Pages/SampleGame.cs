using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Sandbox.GameDev.Domain.Models;
using Sandbox.GameDev.Domain.Models.Base;
using Sandbox.GameDev.Domain.Models.Enums;

namespace Sandbox.GameDev.UI.BlazorApp.Components.Pages;

public class SampleGame : Game
{
    private readonly static Dictionary<string, InputKey> InputSetting = new()
    {
        { "w", InputKey.Up },
        { "s", InputKey.Down },
        { "a", InputKey.Left },
        { "d", InputKey.Right },
    };

    public override Grid Grid => new(tileSize: 32,
                                     columns: 15,
                                     rows: 20,
                                     x: 0,
                                     y: 0);

    public SampleGame(List<ElementReference> elements)
    {
        Input = new(InputSetting);

        World = new(Grid,
        [
            new()
            {
                BackgroundLayer = elements[0],
                ForegroundLayer = elements[1]
            }
        ]);

        Hero = new(tileSize: Grid.TileSize,
                   game: this,
                   sprite: new Sprite(image: elements[2],
                                      position: new Position(0, 0),
                                      dimensions: new Dimensions(64, 64)),
                   position: new Position(Grid.TileSize * 1,
                                          Grid.TileSize * 2),
                   scale: 1,
                   speed: 2);
    }

    public async override void RenderAsync(Canvas2DContext context)
    {
        await context.BeginBatchAsync();
        await context.ClearRectAsync(0, 0, Grid.Width, Grid.Height);
        Hero.Update();
        World.DrawBackgroundAsync(context);
        World.DrawGridAsync(context);
        Hero.DrawAsync(context);
        World.DrawForegroundAsync(context);
        await context.EndBatchAsync();
    }

}
