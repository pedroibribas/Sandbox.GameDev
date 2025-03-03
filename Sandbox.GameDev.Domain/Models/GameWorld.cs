using Blazor.Extensions.Canvas.Canvas2D;

namespace Sandbox.GameDev.Domain.Models
{
    public class GameWorld(Grid grid, List<WorldLevel> levels)
    {
        public Grid Grid { get; private set; } = grid;
        public List<WorldLevel> Levels { get; set; } = levels;

        public async void DrawGridAsync(Canvas2DContext context)
        {
            for (int row = 0; row < Grid.Rows; row++)
            {
                for (int col = 0; col < Grid.Columns; col++)
                {
                    await context.SetStrokeStyleAsync("black");
                    await context.SetLineWidthAsync(2);
                    await context.StrokeRectAsync(Grid.TileSize * col + Grid.X,
                                                  Grid.TileSize * row + Grid.Y,
                                                  Grid.TileSize,
                                                  Grid.TileSize);
                }
            }
        }

        public void DrawBackgroundAsync(Canvas2DContext context)
        {
            context.DrawImageAsync(Levels[0].BackgroundLayer, 0, 0);
        }

        public void DrawForegroundAsync(Canvas2DContext context)
        {
            context.DrawImageAsync(Levels[0].ForegroundLayer, 0, 0);
        }
    }
}
