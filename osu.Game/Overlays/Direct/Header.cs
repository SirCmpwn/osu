using System;
using System.ComponentModel;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;
using Container = osu.Framework.Graphics.Containers.Container;

namespace osu.Game.Overlays.Direct
{
    public class Header : Container
    {
        public Header()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
        }

        private enum DirectTab
        {
            [Description("Newest Maps")]
            New,
            [Description("Top Rated")]
            Top,
            [Description("Most Played")]
            MostPlayed,
            Search,
        }
        
        [BackgroundDependencyLoader(permitNulls: true)]
        private void load(OsuGame game, OsuColour colours)
        {
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = OsuColour.FromHex(@"252f3a"),
                },
                new FillFlowContainer
                {
                    Direction = FillDirection.Vertical,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Padding = new MarginPadding
                    {
                        Left = DirectOverlay.HORIZONTAL_MARGIN,
                        Right = DirectOverlay.HORIZONTAL_MARGIN
                    },
                    Children = new Drawable[]
                    {
                        new Container
                        {
                            AutoSizeAxes = Axes.Y,
                            RelativeSizeAxes = Axes.X,                            
                            Margin = new MarginPadding
                            {
                                Top = 16 + (game?.Toolbar.DrawHeight ?? 0),
                                Bottom = 16,
                            },
                            Children = new Drawable[]
                            {
                                new SpriteText
                                {
                                    Text = "osu!direct",
                                    TextSize = 32,
                                },
                                new Container
                                {
                                    AutoSizeAxes = Axes.Both,
                                    RelativePositionAxes = Axes.None,
                                    Position = new Vector2(-32, 6),
                                    Children = new[]
                                    {
                                        new TextAwesome
                                        {
                                            Icon = FontAwesome.fa_osu_chevron_down_o,
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            TextSize = 24,
                                        }
                                    }
                                },
                            }
                        },
                        new DirectTabControl<DirectTab>
                        {
                            BackgroundBorderColour = colours.Green,
                            BorderColour = Color4.White,
                            AutoSize = true,
                        },
                    }
                }
            };
        }
    }
}