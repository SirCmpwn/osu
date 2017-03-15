using System;
using osu.Framework.Screens.Testing;
using osu.Game.Overlays;

namespace osu.Desktop.VisualTests.Tests
{
    public class TestCaseDirect : TestCase
    {
        public override string Description => @"Tests the osu!direct overlay";

        private DirectOverlay direct;

        public override void Reset()
        {
            base.Reset();

            Children = new[] { direct = new DirectOverlay() };
            direct.ToggleVisibility();
        }
    }
}
