using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace osu.Game.Graphics.UserInterface
{
    public class OsuDropDownEnumMenu<T> : OsuDropDownMenu<T>
    {
        public static List<KeyValuePair<string, T>> GetItems()
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("OsuDropDownMenu only supports enums as the generic type argument");

            List<KeyValuePair<string, T>> items = new List<KeyValuePair<string, T>>();
            foreach (var val in (T[])Enum.GetValues(typeof(T)))
            {
                var field = typeof(T).GetField(Enum.GetName(typeof(T), val));
                items.Add(
                    new KeyValuePair<string, T>(
                        field.GetCustomAttribute<DescriptionAttribute>()?.Description ?? Enum.GetName(typeof(T), val),
                        val
                    )
                );
            }
            return items;
        }
        
        public OsuDropDownEnumMenu()
        {
            Items = GetItems();
        }
    }
}