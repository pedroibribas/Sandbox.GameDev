using Microsoft.AspNetCore.Components;
using Sandbox.GameDev.Domain.Models.Enums;

namespace Sandbox.GameDev.Domain.Models;

public abstract class Sprite
{
    public ElementReference Image { get; }
    public Position CurrentPosition { get; set; }
    public abstract Dictionary<SpriteState, SpriteStateSettings> StateSettings { get; }
    public abstract Dimensions Dimensions { get; }

    public Sprite(ElementReference image)
    {
        Image = image;
        
        CurrentPosition = new(X: 0,
                              Y: StateSettings[SpriteState.Still].StartingPosition);
    }

    /// <summary>
    /// Troca a posição do sprite no eixo Y, navegando verticalmente.
    /// </summary>
    /// <param name="state"></param>
    public void ChangeSpriteState(SpriteState state)
    {
        CurrentPosition.Y = StateSettings[state].StartingPosition;
    }
    /// <summary>
    /// Troca a posição do sprite no eixo X, navegando horizontalmente.
    /// </summary>
    public void ChangeStateFrame(SpriteState state)
    {
        if (CurrentPosition.X < StateSettings[state].MaxFrameCount)
        {
            CurrentPosition.X++;
        }
        else CurrentPosition.X = 0;
    }
}
