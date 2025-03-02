using Blazor.Extensions.Canvas.Canvas2D;
using Sandbox.GameDev.Domain.Models.Base;

namespace Sandbox.GameDev.Domain.Models;

public class Hero :
    GameObject
{
    public int Speed { get; private set; }

    public Hero(double tileSize, Game game, Sprite sprite, Position position, double scale, int speed) : base(tileSize, game, sprite, position, scale)
    {
        Speed = speed;
    }

    public override void DrawAsync(Canvas2DContext context)
    {
        base.DrawAsync(context);
    }

    public void Update()
    {
        double nextX = DestinationPosition.X;
        double nextY = DestinationPosition.Y;

        double distance = MoveTo(DestinationPosition, Speed);

        bool arrived = distance <= Speed;

        if (arrived)
        {
            if (Game.Input.Keys.Count == 0)
            {
                return;
            }

            if (Game.Input.LastKey == Enums.InputKey.Up)
            {
                nextY -= TileSize;
            }
            else if (Game.Input.LastKey == Enums.InputKey.Down)
            {
                nextY += TileSize;
            }
            else if (Game.Input.LastKey == Enums.InputKey.Left)
            {
                nextX -= TileSize;
            }
            else if (Game.Input.LastKey == Enums.InputKey.Right)
            {
                nextX += TileSize;
            }

            // Recalc
            DestinationPosition.X = nextX;
            DestinationPosition.Y = nextY;
        }
    }

}
