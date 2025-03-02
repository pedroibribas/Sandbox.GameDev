namespace Sandbox.GameDev.Domain.Models
{
    public class Dimensions
    {
        public Dimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
