using Microsoft.Xna.Framework;
namespace MonoMaze.Models;

public class TilesheetAtlas
{
    public string ImagePath { get; set; }
    public AtlasItem[] SubTexture { get; set; }

}

public class AtlasItem
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle GetRectangle()
    {
        return new Rectangle(X, Y, Width, Height);
    }
}
