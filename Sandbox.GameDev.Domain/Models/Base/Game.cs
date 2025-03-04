using Blazor.Extensions.Canvas.Canvas2D;
using Sandbox.GameDev.Domain.Interfaces;

namespace Sandbox.GameDev.Domain.Models.Base;

public abstract class Game()
{
    public abstract Grid Grid { get; }
    public IGameWorld World { get; set; } = null!;
    public List<Sprite> Sprites { get; set; } = null!;
    public GameInput Input { get; set; } = null!;
    public Hero Hero { get; set; } = null!;

    public bool DebugMode = false;

    public abstract void RenderAsync(Canvas2DContext context, float timeStamp);
}