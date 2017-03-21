using System;
using OpenTK;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;

namespace osu.Game.Overlays.Direct
{
    public class BeatmapList : FillFlowContainer
    {
        public BeatmapList()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
            Direction = FillDirection.Vertical;
            Padding = new MarginPadding
            {
                Top = 5,
                Left = DirectOverlay.HORIZONTAL_MARGIN - BeatmapPanel.PADDING,
                Right = DirectOverlay.HORIZONTAL_MARGIN  - BeatmapPanel.PADDING,
            };
        }
        
        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            Children = new[]
            {
                new SpriteText
                {
                    Colour = colours.Yellow,
                    Text = "Found 1 artist, 432 songs, 3 tags",
                    TextSize = 14,
                    Margin = new MarginPadding { Left = 10, Bottom = 5 },
                },
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Children = new[]
                    {
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                        new BeatmapPanel(),
                    }
                }
            };
        }
    }
}