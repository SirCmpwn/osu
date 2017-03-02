using System;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;
using osu.Game.Modes;

namespace osu.Game.Overlays.Direct
{
    public class Search : Container
    {
        public Search()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
        }
        
        [BackgroundDependencyLoader(permitNulls: true)]
        private void load(OsuGame game)
        {
            Bindable<PlayMode> playMode = game?.PlayMode ?? new Bindable<PlayMode>();
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = OsuColour.FromHex(@"3a4551"),
                },
                new FlowContainer
                {
                    Direction = FlowDirections.Vertical,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Margin = new MarginPadding
                    {
                        Left = DirectOverlay.HORIZONTAL_MARGIN,
                        Right = DirectOverlay.HORIZONTAL_MARGIN,
                    },
                    Children = new Drawable[]
                    {
                        new FlowContainer
                        {
                            Direction = FlowDirections.Horizontal,
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Spacing = new Vector2(5, 0),
                            Padding = new MarginPadding { Top = 5 },
                            Children = new[]
                            {
                                new ModeToggleButton(playMode, PlayMode.Osu),
                                new ModeToggleButton(playMode, PlayMode.Taiko),
                                new ModeToggleButton(playMode, PlayMode.Catch),
                                new ModeToggleButton(playMode, PlayMode.Mania),
                            }
                        },
                        new Container
                        {
                            AutoSizeAxes = Axes.Both,
                            Margin = new MarginPadding { Top = 5 },
                            Children = new[]
                            {
                                new SpriteText { Text = "TODO: tabs" }
                            }
                        }
                    }
                },
                new Box
                {
                    RelativeSizeAxes = Axes.X,
                    RelativePositionAxes = Axes.Y,
                    Position = new Vector2(0, 1),
                    Colour = OsuColour.FromHex(@"facc39"),
                    Height = 1,
                },
            };
        }

        private class ModeToggleButton : ClickableContainer
        {
            private TextAwesome icon;
            
            private PlayMode mode;
            public PlayMode Mode
            {
                get { return mode; }
                set
                {
                    mode = value;
                    icon.Icon = Ruleset.GetRuleset(mode).Icon;
                }
            }

            private Bindable<PlayMode> bindable;

            void Bindable_ValueChanged(object sender, EventArgs e)
            {
                if (Mode == bindable.Value)
                    icon.Colour = Color4.White;
                else
                    icon.Colour = OsuColour.FromHex(@"6b747d");
            }
        
            public ModeToggleButton(Bindable<PlayMode> bindable, PlayMode mode)
            {
                this.bindable = bindable;
                AutoSizeAxes = Axes.Both;
                Children = new[]
                {
                    icon = new TextAwesome
                    {
                        Origin = Anchor.TopLeft,
                        Anchor = Anchor.TopLeft,
                        TextSize = 32,
                    }
                };
                Mode = mode;
                bindable.ValueChanged += Bindable_ValueChanged;
                Bindable_ValueChanged(null, null);
                Action = () => bindable.Value = Mode;
            }
            
            protected override void Dispose(bool isDisposing)
            {
                if (bindable != null)
                    bindable.ValueChanged -= Bindable_ValueChanged;
                base.Dispose(isDisposing);
            }
        }
    }
}