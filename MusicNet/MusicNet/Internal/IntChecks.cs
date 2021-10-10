using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Internal
{
    internal static class IntChecks
    {
        public static int EnsureArgPositive(int value, string argName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    $"expected positive value for argument \"{argName}\"");
            }
            return value;
        }

        public static int EnsurePropPositive(int value, string propName)
        {
            if (value <= 0)
            {
                throw new InvalidOperationException(
                    $"expected positive value for property \"{propName}\"");
            }
            return value;
        }

        public static int EnsureArgNonNegative(int value, string argName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    $"expected non-negative value for argument \"{argName}\"");
            }
            return value;
        }

        public static int EnsurePropNonNegative(int value, string propName)
        {
            if (value <= 0)
            {
                throw new InvalidOperationException(
                    $"expected non-negative value for property \"{propName}\"");
            }
            return value;
        }
    }
}
