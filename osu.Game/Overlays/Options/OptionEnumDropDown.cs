// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Overlays.Options
{
    public class OptionEnumDropDown<T> : OptionDropDown<T>
    {
        public OptionEnumDropDown()
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("OptionsDropdown only supports enums as the generic type argument");

            Items = OsuDropDownEnumMenu<T>.GetItems();
        }
    }
}
