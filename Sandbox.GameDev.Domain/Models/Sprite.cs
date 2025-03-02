using Microsoft.AspNetCore.Components;

namespace Sandbox.GameDev.Domain.Models;

public class Sprite
{
    public ElementReference Image { get; }
    public Position Position { get; set; }
    public Dimensions Dimensions { get; }

    public Sprite(ElementReference image, Position position, Dimensions dimensions)
    {
        Image = image;
        Position = position;
        Dimensions = dimensions;
    }
}