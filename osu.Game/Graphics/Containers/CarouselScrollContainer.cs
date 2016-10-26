using System;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Transformations;

namespace osu.Game.Graphics.Containers
{
    public class CarouselScrollContainer : ScrollContainer
    {
        /// <summary>
        /// The container whose children should be "carouseled" as this container is scrolled.
        /// </summary>
        public Container CarouselContainer;

        private float centre = 0.5f;
        private float min;
        private float max;
        private bool isScrolling;
        
        public float Centre
        {
            get { return centre; }
            set
            {
                centre = value;
                UpdateScroll(true);
            }
        }
        
        public float Min
        {
            get { return min; }
            set
            {
                min = value;
                UpdateScroll(true);
            }
        }
        
        public float Max
        {
            get { return max; }
            set
            {
                max = value;
                UpdateScroll(true);
            }
        }
        
        protected override void UpdateScroll(bool animated = true)
        {
            if (isScrolling || CarouselContainer == null)
                return;
            isScrolling = true;
            base.UpdateScroll(animated);
            float adjusted = (current + currentClamped) / 2;
            // TODO: Don't iterate over the entire list
            // only practical after the same change is made in ScrollContainer
            foreach (var child in CarouselContainer.Children)
            {
                float y = child.Position.Y - adjusted;
                if (y >= DrawHeight)
                    break;
                if (y + child.DrawHeight < 0)
                    continue;
                float relativeY = y / DrawHeight;
                float x = 4 * (float)Math.Pow(relativeY - Centre, 2);
                x = (x - Min) * Max + Min;
                child.MoveToX(x, /*animated ? 800 : */0, EasingTypes.OutExpo);
            }
            isScrolling = false;
        }
    }
}