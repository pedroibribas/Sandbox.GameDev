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
    private bool IsMoving = false;
    public int Speed { get; } = speed;

    public override void DrawAsync(Canvas2DContext context)
    {
        base.DrawAsync(context);
    }

    public void Update(bool updateEvent, float deltaTime)
    {
        double nextX = DestinationPosition.X;
        double nextY = DestinationPosition.Y;

        // Adjust to consistent speed throughout diferents devices
        float scaledSpeed = Speed * (deltaTime / 1000); // px per secs

        double distance = MoveTo(DestinationPosition, scaledSpeed);

        bool hasArrived = distance <= scaledSpeed;

        SpriteState spriteState = default;

        if (hasArrived)
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
            int col = (int)(nextX / TileSize);
            int row = (int)(nextY / TileSize);
            if (Game.World.GetTile(Game.World.CurrentWorldLevel.CollisionLayer, row, col) != 1)
            {
                DestinationPosition.X = nextX;
                DestinationPosition.Y = nextY;
            }
        }

        SetIsMoving(hasArrived);
        if (updateEvent && IsMoving)
        {
            Sprite.ChangeStateFrame(spriteState);
        }
        else if (!IsMoving)
        {
            Sprite.CurrentPosition.X = 0;
        }
    }

    private void SetIsMoving(bool hasArrived)
    {
        if (Game.Input.Keys.Count > 0 || !hasArrived)
        {
            IsMoving = true;
        }
        else IsMoving = false;
    }
}
