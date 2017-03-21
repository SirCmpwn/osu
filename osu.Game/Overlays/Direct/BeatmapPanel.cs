using System;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Game.Beatmaps.Drawables;
using osu.Game.Database;
using osu.Game.Graphics;
using osu.Game.Modes;

namespace osu.Game.Overlays.Direct
{
    public class BeatmapPanel : Container
    {
        public const int PADDING = 5;

        public BeatmapPanel()
        {
            Width = 1f / 3f;
            Padding = new MarginPadding(PADDING);
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
        }
        
        [BackgroundDependencyLoader]
        private void Load(OsuColour colours)
        {
            Children = new[]
            {
                new Container
                {
                    Masking = true,
                    CornerRadius = 5,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    EdgeEffect = new EdgeEffect
                    {
                        Type = EdgeEffectType.Shadow,
                        Colour = OsuColour.Gray(0.2f),
                        Radius = 3,
                        Offset = new Vector2(1),
                    },
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Colour = Color4.White,
                            RelativeSizeAxes = Axes.Both,
                        },
                        new FillFlowContainer
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Direction = FillDirection.Vertical,
                            Children = new Drawable[]
                            {
                                new Container
                                {
                                    RelativeSizeAxes = Axes.X,
                                    Height = 50,
                                    Children = new[]
                                    {
                                        new Box
                                        {
                                            Colour = colours.BlueDarker,
                                            RelativeSizeAxes = Axes.Both,
                                        }
                                    }
                                },
                                new LowerInfoBox()
                            }
                        }
                    }
                },
            };
        }

        private class LowerInfoBox : FillFlowContainer
        {
            public LowerInfoBox()
            {
                RelativeSizeAxes = Axes.X;
                AutoSizeAxes = Axes.Y;
                Direction = FillDirection.Vertical;
                Padding = new MarginPadding
                {
                    Bottom = 5,
                    Top = 5,
                    Left = 10,
                    Right = 10,
                };
                Children = new[]
                {
                    new SpriteText
                    {
                        Text = "mapped by TicClick",
                        Colour = OsuColour.Gray(0.4f),
                        TextSize = 14,
                    },
                    new SpriteText
                    {
                        Text = "from Cardcaptor Sakura",
                        Colour = OsuColour.Gray(0.4f),
                        TextSize = 14,
                    },
                    new FillFlowContainer
                    {
                        Margin = new MarginPadding { Top = 5 },
                        AutoSizeAxes = Axes.Both,
                        Children = new[]
                        {
                            new DifficultyIcon(new BeatmapInfo { Mode = PlayMode.Osu }),
                            new DifficultyIcon(new BeatmapInfo { Mode = PlayMode.Osu }),
                            new DifficultyIcon(new BeatmapInfo { Mode = PlayMode.Osu }),
                            new DifficultyIcon(new BeatmapInfo { Mode = PlayMode.Taiko }),
                        }
                    }
                };
            }
        }
    }
}