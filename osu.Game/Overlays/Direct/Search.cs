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
using osu.Game.Graphics.UserInterface;
using osu.Game.Modes;
using osu.Game.Screens.Select;

namespace osu.Game.Overlays.Direct
{
    public class Search : Container
    {
        public Search()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
        }
        
        public enum SortCriteria
        {
            Title,
            Artist,
            Creator,
            Difficulty,
            Ranked,
            Rating,
            Plays,
        }

        public enum FilterCriteria
        {
            Ranked,
            Qualified,
            Loved,
            Pending,
        }

        private SortCriteria sortCriteria;
        
        [BackgroundDependencyLoader(permitNulls: true)]
        private void load(OsuGame game, OsuColour colours)
        {
            Bindable<PlayMode> playMode = game?.PlayMode ?? new Bindable<PlayMode>();
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = OsuColour.FromHex(@"3a4551"),
                },
                new FillFlowContainer
                {
                    Direction = FillDirection.Vertical,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Padding = new MarginPadding
                    {
                        Top = 5,
                        Left = DirectOverlay.HORIZONTAL_MARGIN,
                        Right = DirectOverlay.HORIZONTAL_MARGIN,
                    },
                    Spacing = new Vector2(0, 5),
                    Children = new Drawable[]
                    {
                        new SearchTextBox
                        {
                            RelativeSizeAxes = Axes.X
                        },
                        new FillFlowContainer
                        {
                            Direction = FillDirection.Horizontal,
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Spacing = new Vector2(5, 0),
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
                            AutoSizeAxes = Axes.Y,
                            RelativeSizeAxes = Axes.X,
                            Children = new Drawable[]
                            {
                                new DirectTabControl<SortCriteria>
                                {
                                    RelativeSizeAxes = Axes.X,
                                    Width = 0.5f,
                                    BorderColour = colours.Yellow,
                                    BorderHeight = 4,
                                },
                                new SlimDropDownMenu<FilterCriteria>
                                {
                                    Width = 200,
                                    Anchor = Anchor.TopRight,
                                    Origin = Anchor.TopRight,
                                    SelectedValue = FilterCriteria.Ranked
                                },
                            }
                        }
                    }
                },
                new Box
                {
                    RelativeSizeAxes = Axes.X,
                    RelativePositionAxes = Axes.Y,
                    Position = new Vector2(0, 1),
                    Colour = colours.Yellow,
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