using Sandbox.GameDev.Domain.Models;

namespace Sandbox.GameDev.UI.BlazorApp.Components.Models;

public class SampleGameWorld(Grid grid, List<WorldLevel> levels, WorldLevel currentWorldLevel) : GameWorld(grid, levels, currentWorldLevel)
{
}
