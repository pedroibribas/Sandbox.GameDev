using Blazor.Extensions.Canvas.Canvas2D;

namespace Sandbox.GameDev.Domain.Models
{
    public static class CanvasManager
    {
        public static async Task InitAsync(this Canvas2DContext context, object color, double x, double y, double width, double height)
        {
            await context.SetFillStyleAsync(color);
            await context.FillRectAsync(x, y, width, height);
        }

        //await context.SetFontAsync("48px serif");
        //await context.StrokeTextAsync("Hello Blazor!!!", 10, 100);
    }
}
