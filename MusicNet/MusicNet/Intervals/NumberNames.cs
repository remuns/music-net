using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Intervals
{
    /// <summary>
    /// Represents a name of the number of a simple perfectable interval.
    /// </summary>
    public enum SimplePIntervalNumberName
    {
        /// <summary>
        /// Represents a unison.
        /// </summary>
        Unison,

        /// <summary>
        /// Represents a fourth.
        /// </summary>
        Fourth,

        /// <summary>
        /// Represents a fifth.
        /// </summary>
        Fifth,
    }

    /// <summary>
    /// Represents a name of the number of a simple non-perfectable interval.
    /// </summary>
    public enum SimpleNPIntervalNumberName
    {
        /// <summary>
        /// Represents a second.
        /// </summary>
        Second,

        /// <summary>
        /// Represents a third.
        /// </summary>
        Third,

        /// <summary>
        /// Represents a sixth.
        /// </summary>
        Sixth,

        /// <summary>
        /// Represents a seventh.
        /// </summary>
        Seventh,
    }

    /// <summary>
    /// Static functionality for working with simple interval number names.
    /// </summary>
    public static class SimpleIntervalNumberNames
    {
#pragma warning disable CS8524 // Exception should be thrown if enum value is unnamed
        /// <summary>
        /// Gets the number that the current name is for.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Number(this SimplePIntervalNumberName n) => n switch
        {
            SimplePIntervalNumberName.Unison => 1,
            SimplePIntervalNumberName.Fourth => 4,
            SimplePIntervalNumberName.Fifth => 5,
        };

        /// <summary>
        /// Gets the number that the current name is for.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Number(this SimpleNPIntervalNumberName n) => n switch
        {
            SimpleNPIntervalNumberName.Second => 2,
            SimpleNPIntervalNumberName.Third => 3,
            SimpleNPIntervalNumberName.Sixth => 6,
            SimpleNPIntervalNumberName.Seventh => 7,
        };
#pragma warning restore CS8524 
    }
}
