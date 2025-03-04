using Microsoft.AspNetCore.Components;
using Sandbox.GameDev.Domain.Interfaces;
using Sandbox.GameDev.Domain.Models;

namespace TheChant.Components.Models;

public class TheChantWorld : GameWorldV2, IGameWorld
{
    public TheChantWorld(List<ElementReference> resources, Grid grid) : base()
    {
        Grid = grid;

        Levels = [
            AddLevel1Map(resources)
        ];

        CurrentWorldLevel = Levels[0];
    }

    private static WorldLevel AddLevel1Map(List<ElementReference> resources)
    {
        return new()
        {
            GroundLayer = [
            1,2,3,14,14,
            6,7,8,14,14,
            11,12,13,14,14,
            14,14,14,14,14,
            14,14,14,14,14,
        ],
            Dimensions = new(160, 160)
        };
    }
}
