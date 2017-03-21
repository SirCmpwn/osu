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
    public class DirectOverlay : WaveOverlayContainer
    {
        public const float TRANSITION_LENGTH = 600;
        
        internal const int HORIZONTAL_MARGIN = 75;

        private Container<Drawable> upperContainer;
        private ScrollContainer resultsContainer;
    
        public DirectOverlay()
        {
            FirstWaveColour = OsuColour.FromHex(@"19b0e2");
            SecondWaveColour = OsuColour.FromHex(@"2280a2");
            ThirdWaveColour = OsuColour.FromHex(@"005774");
            FourthWaveColour = OsuColour.FromHex(@"003a4e");
            
            Content.RelativeSizeAxes = RelativeSizeAxes = Axes.Both;
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    // TODO: Where to put these colors in the long term?
                    Colour = OsuColour.FromHex(@"445568")
                },
                new DirectTriangles { RelativeSizeAxes = Axes.Both },
                upperContainer = new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Children = new Drawable[]
                    {
                        new Header(),
                        new SearchControl(),
                    }
                },
                resultsContainer = new ScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new[]
                    {
                        new BeatmapList()
                    }
                },
            };
        }
        
        protected override void UpdateAfterChildren()
        {
            base.Update();
            resultsContainer.Margin = new MarginPadding { Top = upperContainer.DrawHeight };
            resultsContainer.Height = 1 - upperContainer.DrawHeight / DrawHeight;
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
