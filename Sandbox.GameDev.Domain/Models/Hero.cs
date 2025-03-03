using Blazor.Extensions.Canvas.Canvas2D;
using Sandbox.GameDev.Domain.Models.Base;
using Sandbox.GameDev.Domain.Models.Enums;

namespace Sandbox.GameDev.Domain.Models;

public class Hero(double tileSize,
                  Game game,
                  Sprite sprite,
                  Position position,
                  double scale,
                  int speed) : GameObject(tileSize, game, sprite, position, scale)
{
    public int Speed { get; } = speed;

    public override void DrawAsync(Canvas2DContext context)
    {
        base.DrawAsync(context);
    }

    public void Update(bool updateEvent)
    {
        double nextX = DestinationPosition.X;
        double nextY = DestinationPosition.Y;

        double distance = MoveTo(DestinationPosition, Speed);

        bool arrived = distance <= Speed;

        SpriteState spriteState = default;

        if (arrived)
        {
            if (Game.Input.Keys.Count == 0)
            {
                return;
            }

            if (Game.Input.LastKey == InputKey.Up)
            {
                spriteState = SpriteState.WalkingUp;

                nextY -= TileSize;
            }
            else if (Game.Input.LastKey == InputKey.Down)
            {
                spriteState = SpriteState.WalkingDown;

                nextY += TileSize;
            }
            else if (Game.Input.LastKey == InputKey.Left)
            {
                spriteState = SpriteState.WalkingLeft;

                nextX -= TileSize;
            }
            else if (Game.Input.LastKey == InputKey.Right)
            {
                spriteState = SpriteState.WalkingRight;

                nextX += TileSize;
            }

            Sprite.ChangeSpriteState(spriteState);

            // Recalc
            DestinationPosition.X = nextX;
            DestinationPosition.Y = nextY;
        }

        if (updateEvent)
        {
            Sprite.ChangeStateFrame(spriteState);
        }
    }

}
