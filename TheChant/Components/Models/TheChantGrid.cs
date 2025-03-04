using Sandbox.GameDev.Domain.Models;

namespace TheChant.Components.Models;

public class TheChantGrid : Grid
{
    private static readonly int tileSize = 32;
    private static readonly int columns = 5;
    private static readonly int rows = 5;
    private static readonly int x = 0;
    private static readonly int y = 0;

    public TheChantGrid() : base(tileSize, columns, rows, x, y)
    {
    }
}
