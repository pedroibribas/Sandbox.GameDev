using Blazor.Extensions.Canvas.Canvas2D;

namespace Sandbox.GameDev.Domain.Models.Base;

public abstract class GameObject
{
    public string Id { get; } = Guid.NewGuid().ToString();

    protected double TileSize { get; }
    public Game Game { get; }
    public Sprite Sprite { get; }
    public double Scale { get; }

    public Position Position { get; set; }
    public Position DestinationPosition { get; set; }
    public Position DistanceToDestination { get; set; }

    public GameObject(double tileSize, Game game, Sprite sprite, Position position, double scale)
    {
        TileSize = tileSize;
        Game = game;
        Sprite = sprite;
        Scale = scale;
        Position = position;

        DestinationPosition = new(Position.X, Position.Y);
        DistanceToDestination = new(0, 0);
    }

    public virtual async void DrawAsync(Canvas2DContext context)
    {
        await context.SetFillStyleAsync("blue");
        await context.FillRectAsync(x: Position.X,
                                    y: Position.Y,
                                    width: TileSize,
                                    height: TileSize);

        await context.SetStrokeStyleAsync("yellow");
        await context.SetLineWidthAsync(2);
        await context.StrokeRectAsync(x: DestinationPosition.X,
                                    y: DestinationPosition.Y,
                                    width: TileSize,
                                    height: TileSize);

        await context.DrawImageAsync(Sprite.Image,
                                     Position.X,
                                     Position.Y,
                                     Sprite.Dimensions.Width,
                                     Sprite.Dimensions.Height);
    }

    public double MoveTo(Position destinationPosition, int speed)
    {
        DistanceToDestination.X = destinationPosition.X - Position.X;
        DistanceToDestination.Y = destinationPosition.Y - Position.Y;

        double distance = double.Hypot(DistanceToDestination.X, DistanceToDestination.Y);

        if (distance <= speed)
        {
            // End movement
            Position.X = destinationPosition.X;
            Position.Y = destinationPosition.Y;
        }
        else
        {
            // Move one step
            double stepX = DistanceToDestination.X / distance;
            double stepY = DistanceToDestination.Y / distance;
            Position.X += stepX * speed;
            Position.Y += stepY * speed;

            // Recalc
            DistanceToDestination.X = destinationPosition.X - Position.X;
            DistanceToDestination.Y = destinationPosition.Y - Position.Y;
            distance = double.Hypot(DistanceToDestination.X, DistanceToDestination.Y);
        }

        return distance;
    }

}
