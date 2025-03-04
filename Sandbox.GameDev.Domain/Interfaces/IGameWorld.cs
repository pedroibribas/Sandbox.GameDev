using Blazor.Extensions.Canvas.Canvas2D;
using Sandbox.GameDev.Domain.Models;

namespace Sandbox.GameDev.Domain.Interfaces;

public interface IGameWorld
{
    List<WorldLevel> Levels { get; set; }
    WorldLevel CurrentWorldLevel { get; set; }
    
    int GetTile(int[] array, int row, int column);
    void DrawGridAsync(Canvas2DContext context);
    void DrawCollisionGridAsync(Canvas2DContext context, int[] levelCollisionLayerArray);
    void DrawBackgroundAsync(Canvas2DContext context);
    void DrawForegroundAsync(Canvas2DContext context);
}