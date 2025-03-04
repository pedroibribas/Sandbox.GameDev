using Blazor.Extensions.Canvas.Canvas2D;

namespace Sandbox.GameDev.Domain.Models.Base;

public abstract class GameObject
{
    public string Id { get; } = Guid.NewGuid().ToString();

    protected double TileSize { get; }
    public double HalfTileSize { get; }

    public Game Game { get; }
    public Sprite Sprite { get; }

    public double Width { get; }
    public double HalfWidth { get; }
    public double Height { get; }
    public double HalfHeight { get; }
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

        HalfTileSize = TileSize / 2;
        Width = Sprite.Dimensions.Width * Scale;
        HalfWidth = Width / 2;
        Height = Sprite.Dimensions.Height * Scale;
        HalfHeight = Height / 2;

        DestinationPosition = new(Position.X, Position.Y);
        DistanceToDestination = new(0, 0);
    }

    public virtual void DrawAsync(Canvas2DContext context)
    {
        if (Game.DebugMode)
        {
            DrawObjectShadowAsync(context);
            DrawObjectMovementShadowAsync(context);
        }

        DrawSpriteAsync(context);
    }

    private async void DrawObjectMovementShadowAsync(Canvas2DContext context)
    {
        await context.SetStrokeStyleAsync("yellow");
        await context.SetLineWidthAsync(2);
        await context.StrokeRectAsync(x: DestinationPosition.X,
                                    y: DestinationPosition.Y,
                                    width: TileSize,
                                    height: TileSize);
    }

    public async void DrawObjectShadowAsync(Canvas2DContext context)
    {
        await context.SetFillStyleAsync("rgba(0,0,255,0.7)");
        await context.FillRectAsync(x: Position.X,
                                    y: Position.Y,
                                    width: TileSize,
                                    height: TileSize);
    }

    public async void DrawSpriteAsync(Canvas2DContext context)
    {
        double imgPositionX = Sprite.CurrentPosition.X * Sprite.Dimensions.Width;
        double imgPositionY = Sprite.CurrentPosition.Y * Sprite.Dimensions.Height;
        int imgWidth = Sprite.Dimensions.Width;
        int imgHeight = Sprite.Dimensions.Height;
        double positionX = Position.X + HalfTileSize - HalfWidth;
        double positionY = Position.Y + TileSize - Height;

        await context.DrawImageAsync(
            Sprite.Image, imgPositionX, imgPositionY, imgWidth, imgHeight,
            positionX, positionY, Width, Height);
    }

    public double MoveTo(Position destinationPosition, float speed)
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
