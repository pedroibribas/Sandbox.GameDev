using Blazor.Extensions.Canvas.Canvas2D;
using Sandbox.GameDev.Domain.Interfaces;

namespace Sandbox.GameDev.Domain.Models
{
    public abstract class GameWorldV2() : IGameWorld
    {
        protected virtual Grid Grid { get; set; } = null!;
        public virtual List<WorldLevel> Levels { get; set; } = null!;
        public virtual WorldLevel CurrentWorldLevel { get; set; } = null!;

        public async void DrawGridAsync(Canvas2DContext context)
        {
            await context.SetStrokeStyleAsync("black");
            await context.SetLineWidthAsync(2);
            for (int row = 0; row < Grid.Rows; row++)
            {
                for (int col = 0; col < Grid.Columns; col++)
                {
                    await context.StrokeRectAsync(Grid.TileSize * col + Grid.X,
                                                  Grid.TileSize * row + Grid.Y,
                                                  Grid.TileSize,
                                                  Grid.TileSize);
                }
            }
        }

        public async void DrawCollisionGridAsync(Canvas2DContext context, int[] levelCollisionLayerArray)
        {
            await context.SetFillStyleAsync("rgba(0,0,255,0.5)");

            for (int row = 0; row < Grid.Rows; row++)
            {
                for (int col = 0; col < Grid.Columns; col++)
                {
                    if (GetTile(levelCollisionLayerArray, row, col) == 1)
                    {
                        await context.FillRectAsync(Grid.TileSize * col + Grid.X,
                                                    Grid.TileSize * row + Grid.Y,
                                                    Grid.TileSize,
                                                    Grid.TileSize);
                    }
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

        public int GetTile(int[] array, int row, int column)
        {
            int area = Grid.Columns * row;
            int columnIndex = area + column;

            return array[columnIndex];
        }

    }

}
