using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;
using osu.Game.Graphics.Backgrounds;
using osu.Game.Overlays.Direct;

namespace osu.Game.Overlays
{
    public class DirectOverlay : FocusedOverlayContainer
    {
        public const float TRANSITION_LENGTH = 600;
        
        internal const int HORIZONTAL_MARGIN = 75;
    
        public DirectOverlay()
        {
            RelativeSizeAxes = Axes.Both;
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    // TODO: Where to put these colors in the long term?
                    Colour = OsuColour.FromHex(@"445568")
                },
                new DirectTriangles { RelativeSizeAxes = Axes.Both },
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new Header(),
                        new Search(),
                    }
                }
            };
        }
        
        protected override void PopIn()
        {
            base.PopIn();
            FadeTo(1, TRANSITION_LENGTH / 2);
        }
        
        protected override void PopOut()
        {
            base.PopOut();
            FadeTo(0, TRANSITION_LENGTH / 2);
        }
    }
}
