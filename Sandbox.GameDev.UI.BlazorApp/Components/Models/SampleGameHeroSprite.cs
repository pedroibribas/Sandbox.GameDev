using Microsoft.AspNetCore.Components;
using Sandbox.GameDev.Domain.Models;
using Sandbox.GameDev.Domain.Models.Enums;

namespace Sandbox.GameDev.UI.BlazorApp.Components.Models;

public class SampleGameHeroSprite(ElementReference image) : Sprite(image)
{
    public override Dimensions Dimensions =>  new(64, 64);

    public override Dictionary<SpriteState, SpriteStateSettings> StateSettings => new()
    {
        { SpriteState.Still, new(startingPosition: 8, maxFrameCount: 8) },
        { SpriteState.WalkingUp, new(startingPosition: 8, maxFrameCount: 8) },
        { SpriteState.WalkingLeft, new(startingPosition: 9, maxFrameCount: 8) },
        { SpriteState.WalkingDown, new(startingPosition: 10, maxFrameCount: 8) },
        { SpriteState.WalkingRight, new(startingPosition: 11, maxFrameCount: 8) }
    };
}
