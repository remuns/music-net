using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace REMuns.Music.Internal
{
    internal static class EnumChecks
    {
        public static TEnum EnsureArgNamed<TEnum>(TEnum value, string argName)
        where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                throw new InvalidEnumArgumentException(
                    $"expected named value of type {nameof(TEnum)} for argument \"{argName}\"");
            }
            return value;
        }

        public static TEnum EnsurePropNamed<TEnum>(TEnum value, string propName)
        where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                throw new InvalidOperationException(
                    $"expected named value of type {nameof(TEnum)} for property \"{propName}\"");
            }
            return value;
        }

    }
}
