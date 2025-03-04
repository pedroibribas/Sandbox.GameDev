using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Sandbox.GameDev.Domain.Models;
using Sandbox.GameDev.Domain.Models.Base;

namespace TheChant.Components.Models;

public class TheChant : Game
{
    public override Grid Grid => new TheChantGrid();

    public TheChant(List<ElementReference> resources)
    {
        World = new TheChantWorld(resources, Grid);
    }

    public override async void RenderAsync(Canvas2DContext context, float timeStamp)
    {
        await context.BeginBatchAsync();
        await context.ClearRectAsync(0, 0, Grid.Width, Grid.Height);

        World.DrawBackgroundAsync(context);
        World.DrawForegroundAsync(context);
        World.DrawCollisionGridAsync(context, World.CurrentWorldLevel.CollisionLayer);
        World.DrawGridAsync(context);
        
        await context.EndBatchAsync();
    }
}