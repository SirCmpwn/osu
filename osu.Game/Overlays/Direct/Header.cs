using System;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;

namespace osu.Game.Overlays.Direct
{
    public class Header : Container
    {
        public Header()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
        }
        
        [BackgroundDependencyLoader(permitNulls: true)]
        private void load(OsuGame game)
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
                    Margin = new MarginPadding
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
                        new SpriteText { Text = "TODO: tabs" }
                    }
                }
            };
        }
    }
}