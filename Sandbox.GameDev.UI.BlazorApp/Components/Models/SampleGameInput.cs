using Sandbox.GameDev.Domain.Models;
using Sandbox.GameDev.Domain.Models.Enums;

namespace Sandbox.GameDev.UI.BlazorApp.Components.Models;

public class SampleGameInput : GameInput
{
    protected override Dictionary<string, InputKey> Settings => new()
    {
        { "w", InputKey.Up },
        { "s", InputKey.Down },
        { "a", InputKey.Left },
        { "d", InputKey.Right },
        { "Enter", InputKey.EnableDebug }
    };
}
