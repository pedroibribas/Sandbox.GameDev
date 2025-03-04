using Sandbox.GameDev.Domain.Models;
using Sandbox.GameDev.Domain.Models.Base;

namespace Sandbox.GameDev.UI.BlazorApp.Components.Models;

public class SampleGameHero(double tileSize, Game game, Sprite sprite, Position screenPosition) 
    : Hero(tileSize, game, sprite, screenPosition, scale, speed)
{
    private static readonly double scale = 1.25;
    private static readonly int speed = 100;
}