namespace Sandbox.GameDev.Domain.Models;

public class Grid
{
    public int TileSize { get; }
    public int Columns { get; }
    public int Rows { get; }
    public int Width { get; }
    public int Height { get; }
    public int X { get; }
    public int Y { get; }

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
