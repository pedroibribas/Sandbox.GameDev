using Blazor.Extensions.Canvas.Canvas2D;

namespace Sandbox.GameDev.Domain.Models;

public class Grid
{
    public int TileSize { get; private set; }
    public int Columns { get; private set; }
    public int Rows { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public Grid(int tileSize, int columns, int rows, int x, int y)
    {
        TileSize = tileSize;
        Columns = columns;
        Rows = rows;
        X = x;
        Y = y;

        Width = TileSize * Columns;
        Height = TileSize * Rows;
    }

}
