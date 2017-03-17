using System;
using System.Linq;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Transforms;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Game.Graphics;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Overlays.Direct
{
    public class DirectTabControl<T> : OsuTabControl<T>
    {
        public Color4 BackgroundBorderColour
        {
            get { return backgroundBorder?.Colour ?? Color4.Transparent; }
            set { backgroundBorder.Colour = value; }
        }

        private Color4 borderColour;
        public new Color4 BorderColour
        {
            get { return borderColour; }
            set
            {
                borderColour = value;
                foreach (var item in TabMap.Values.OfType<DirectTabItem<T>>())
                    item.BorderColour = value;
            }
        }
        
        public float BorderHeight
        {
            get { return backgroundBorder?.Height ?? 2; }
            set
            {
                backgroundBorder.Height = value;
                foreach (var item in TabMap.Values.OfType<DirectTabItem<T>>())
                    item.BorderHeight = value;
            }
        }

        private bool autoSize;
        public bool AutoSize
        {
            get { return autoSize; }
            set
            {
                if (autoSize = value)
                {
                    AutoSizeAxes = Axes.X;
                    TabContainer.RelativeSizeAxes = Axes.Y;
                    TabContainer.AutoSizeAxes = Axes.X;
                }
                else
                {
                    AutoSizeAxes = Axes.None;
                    TabContainer.AutoSizeAxes = Axes.None;
                    TabContainer.RelativeSizeAxes = Axes.Both;
                }
            }
        }

        protected override TabItem<T> CreateTabItem(T value)
        {
            return new DirectTabItem<T>(value)
            {
                BorderHeight = BorderHeight,
                BorderColour = BorderColour,
            };
        }

        private Box backgroundBorder;

        public DirectTabControl()
        {
            Height = 24;
            AutoSort = true;
            Add(backgroundBorder = new Box
            {
                RelativeSizeAxes = Axes.X,
                Depth = 1,
                Height = 2,
                Colour = Color4.Transparent,
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
            });
        }

        private class DirectTabItem<U> : TabItem<U>
        {
            private SpriteText text;
            private Box box;
            
            public float BorderHeight
            {
                get { return box.Height; }
                set { box.Height = value; }
            }

            public new Color4 BorderColour
            {
                get { return box.Colour; }
                set { box.Colour = value; }
            }
    
            public new U Value
            {
                get { return base.Value; }
                set
                {
                    base.Value = value;
                    text.Text = (value as Enum)?.GetDescription();
                }
            }
    
            public override bool Active
            {
                get { return base.Active; }
                set
                {
                    if (Active == value) return;
                    if (value)
                        fadeActive();
                    else
                        fadeInactive();
                    base.Active = value;
                }
            }
    
            private const float transition_length = 500;
            private void fadeActive() => box.FadeIn(transition_length, EasingTypes.OutQuint);
            private void fadeInactive() => box.FadeOut(transition_length, EasingTypes.OutQuint);
    
            protected override bool OnHover(InputState state)
            {
                if (!Active)
                    fadeActive();
                return true;
            }
    
            protected override void OnHoverLost(InputState state)
            {
                if (!Active)
                    fadeInactive();
            }

            public DirectTabItem(U value)
            {
                base.Value = value;
                AutoSizeAxes = Axes.X;
                RelativeSizeAxes = Axes.Y;

                Children = new Drawable[]
                {
                    text = new SpriteText
                    {
                        Colour = Color4.White,
                        Margin = new MarginPadding { Left = 5, Right = 5, Top = 5, Bottom = 8 },
                        Origin = Anchor.BottomLeft,
                        Anchor = Anchor.BottomLeft,
                        TextSize = 14,
                        Font = @"Exo2.0-Bold", // Font should only turn bold when active?
                        Text = (value as Enum)?.GetDescription() ?? string.Empty,
                    },
                    box = new Box
                    {
                        RelativeSizeAxes = Axes.X,
                        Height = 2,
                        Alpha = 0,
                        Origin = Anchor.BottomLeft,
                        Anchor = Anchor.BottomLeft,
                    }
                };
            }
        }
    }
}