using Microsoft.AspNetCore.Components;

namespace Sandbox.GameDev.Domain.Models
{
    public class WorldLevel
    {
        public int[] WaterLayer { get; } = [];
        public int[] GroundLayer { get; } = [];
        public ElementReference BackgroundLayer { get; set;  }
        public ElementReference ForegroundLayer { get; set;  }
    }
}