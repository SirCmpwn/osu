using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Overlays.Direct
{
    public class SlimDropDownMenu<T> : OsuDropDownEnumMenu<T>
    {
        protected override DropDownHeader CreateHeader()
            => new SlimHeader { AccentColour = AccentColour };

        private class SlimHeader : OsuDropDownHeader
        {
            public SlimHeader()
            {
                AutoSizeAxes = Axes.Y;
                Foreground.Padding = new MarginPadding
                {
                    Left = Foreground.Padding.Left,
                    Right = Foreground.Padding.Right
                };
            }
        }
    }
}