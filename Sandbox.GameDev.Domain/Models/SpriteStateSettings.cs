namespace Sandbox.GameDev.Domain.Models;

public class SpriteStateSettings(double startingPosition,
                                 double maxFrameCount)
{
    /// <summary>
    /// Posição inicial no eixo Y da imagem.
    /// </summary>
    public double StartingPosition { get; } = startingPosition;

    public double MaxFrameCount { get; } = maxFrameCount;
}