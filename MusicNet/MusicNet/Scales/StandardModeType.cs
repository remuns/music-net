using REMuns.Music.Internal;
using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Scales
{
    /// <summary>
    /// Represents the type of one of the seven standard natural musical modes.
    /// </summary>
    public enum StandardModeType
    {
        /// <summary>
        /// Represents the Lydian mode.
        /// </summary>
        Lydian,

        /// <summary>
        /// Represents the Ionian (major) mode.
        /// </summary>
        Ionian,

        /// <summary>
        /// Represents the Mixolydian mode.
        /// </summary>
        Mixolydian,

        /// <summary>
        /// Represents the Dorian mode.
        /// </summary>
        Dorian,

        /// <summary>
        /// Represents the Aeolian (natural minor) mode.
        /// </summary>
        Aeolian,

        /// <summary>
        /// Represents the Phrygian mode.
        /// </summary>
        Phrygian,

        /// <summary>
        /// Represents the Locrian mode.
        /// </summary>
        Locrian,
    }

    /// <summary>
    /// Static functionality for the <see cref="StandardModeType"/> enum.
    /// </summary>
    public static class StandardModeTypes
    {
#pragma warning disable CS8524 // Exceptions *should* be thrown if the mode type is not defined
        /// <summary>
        /// Gets an index describing the "major" or "minor" qualities of the current standard
        /// mode type.
        /// </summary>
        /// <remarks>
        /// The scale numbers modes based on how "major" or "minor" they are in relation to the
        /// Dorian mode, which is considered "neutral" and is assigned index 0.  The integer
        /// returned is the sum of the number of sharped scale degrees minus the sum of the number
        /// number of flatted scale degrees (with respect to dorian).
        /// </remarks>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int MajorMinorIndex(this StandardModeType type) => type switch
        {
            StandardModeType.Lydian => 3,
            StandardModeType.Ionian => 2,
            StandardModeType.Mixolydian => 1,
            StandardModeType.Dorian => 0,
            StandardModeType.Aeolian => -1,
            StandardModeType.Phrygian => -2,
            StandardModeType.Locrian => -3,
        };
#pragma warning restore CS8524
    }
}
