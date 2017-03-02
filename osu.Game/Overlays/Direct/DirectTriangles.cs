using System;
using osu.Game.Graphics;
using osu.Game.Graphics.Backgrounds;

namespace osu.Game.Overlays.Direct
{
    public class DirectTriangles : Triangles
    {
        protected override float SpawnRatio => 0.5f;
    
        public DirectTriangles()
        {
            TriangleScale = 3;
            ColourDark = OsuColour.FromHex(@"425264");
            ColourLight = OsuColour.FromHex(@"4b5e73");
        }
    }
}