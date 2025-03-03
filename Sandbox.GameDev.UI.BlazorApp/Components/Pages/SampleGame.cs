using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Sandbox.GameDev.Domain.Models;
using Sandbox.GameDev.Domain.Models.Base;
using Sandbox.GameDev.UI.BlazorApp.Components.Models;

namespace Sandbox.GameDev.UI.BlazorApp.Components.Pages;

public class SampleGame : Game
{
    public override Grid Grid => new SampleGameGrid();

    // Events speed controller, at animation refreshment
    private float LastTime = 0;
    private bool UpdateEvent = false;
    private float EventTimer = 0;
    private readonly float EventInterval = 200;

    public async override void RenderAsync(Canvas2DContext context, float timeStamp = 0)
    {
        HandleEventInterval(timeStamp);

        await HandleRenderAsync(context);
    }

    private async Task HandleRenderAsync(Canvas2DContext context)
    {
        await context.BeginBatchAsync();
        await context.ClearRectAsync(0, 0, Grid.Width, Grid.Height);
        Hero.Update(UpdateEvent);
        World.DrawBackgroundAsync(context);
        World.DrawGridAsync(context);
        Hero.DrawAsync(context);
        World.DrawForegroundAsync(context);
        await context.EndBatchAsync();
    }

    private void HandleEventInterval(float timeStamp)
    {
        float deltaTime = timeStamp - LastTime;

        LastTime = timeStamp;

        // Set event update flag to `true` each "X" milliseconds
        if (EventTimer < EventInterval)
        {
            EventTimer += deltaTime;
            UpdateEvent = false;
        }
        else
        {
            // EventTimer = 0;
            EventTimer = EventInterval % EventTimer; // More precise than above
            
            UpdateEvent = true;
        }
    }

    public SampleGame(List<ElementReference> elements)
    {
        Sprites = MapBlazorElementsToSprites(elements);
        Input = new SampleGameInput();
        World = new SampleGameWorld(Grid, MapBlazorElementsToWorldLevel(elements));
        Hero = new SampleGameHero(tileSize: Grid.TileSize,
                                  game: this,
                                  sprite: Sprites[0],
                                  screenPosition: new Position(Grid.TileSize * 1, Grid.TileSize * 2));
    }

    private static List<Sprite> MapBlazorElementsToSprites(List<ElementReference> elements) => [
            new SampleGameHeroSprite(elements[2])
        ];

    private static List<WorldLevel> MapBlazorElementsToWorldLevel(List<ElementReference> elements) => [
            new()
            {
                BackgroundLayer = elements[0],
                ForegroundLayer = elements[1]
            }
        ];

}
