using Blazor.Extensions.Canvas.Canvas2D;

namespace Sandbox.GameDev.Domain.Models.Base;

public abstract class Game()
{
    public Hero Hero { get; set; } = null!;

    public GameInput Input { get; set; } = null!;
    
    public abstract Grid Grid { get; }

    public GameWorld World { get; set; } = null!;

    public abstract void RenderAsync(Canvas2DContext context);
}