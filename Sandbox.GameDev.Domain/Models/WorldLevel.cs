using Microsoft.AspNetCore.Components;

namespace Sandbox.GameDev.Domain.Models
{
    public class WorldLevel
    {
        public int[] WaterLayer { get; set; } = [];
        public int[] GroundLayer { get; set; } = [];
        public int[] CollisionLayer { get; set; } = [];
        public ElementReference BackgroundLayer { get; set; }
        public ElementReference ForegroundLayer { get; set; }
    }
}