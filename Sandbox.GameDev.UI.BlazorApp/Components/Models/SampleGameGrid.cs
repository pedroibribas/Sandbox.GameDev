using Sandbox.GameDev.Domain.Models;

namespace Sandbox.GameDev.UI.BlazorApp.Components.Models;

public class SampleGameGrid : Grid
{
    private static readonly int tileSize = 32;
    private static readonly int columns = 15;
    private static readonly int rows = 20;
    private static readonly int x = 0;
    private static readonly int y = 0;

    public SampleGameGrid() : base(tileSize, columns, rows, x, y)
    {
    }
}