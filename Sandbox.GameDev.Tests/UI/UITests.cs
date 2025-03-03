using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Sandbox.GameDev.UI.BlazorApp.Components.Pages;

namespace Sandbox.GameDev.Tests;

public class UITests
{
    [Fact]
    public async void ShouldRenderGame()
    {
        BECanvasComponent blazorCanvasComponent = new();

        List<ElementReference> blazorComponents =
        [
            new ElementReference()
        ];

        Canvas2DContext context = await blazorCanvasComponent.CreateCanvas2DAsync();

        SampleGame sampleGame = new(blazorComponents);

        sampleGame.RenderAsync(context);
    }
}