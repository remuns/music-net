using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Intervals
{
    /// <summary>
    /// Represents a name of the number of a simple perfectable interval.
    /// </summary>
    public enum PSimpleIntervalNumberName
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
    public enum NPSimpleIntervalNumberName
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
        public static int Number(this PSimpleIntervalNumberName n) => n switch
        {
            PSimpleIntervalNumberName.Unison => 1,
            PSimpleIntervalNumberName.Fourth => 4,
            PSimpleIntervalNumberName.Fifth => 5,
        };

        /// <summary>
        /// Gets the number that the current name is for.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Number(this NPSimpleIntervalNumberName n) => n switch
        {
            NPSimpleIntervalNumberName.Second => 2,
            NPSimpleIntervalNumberName.Third => 3,
            NPSimpleIntervalNumberName.Sixth => 6,
            NPSimpleIntervalNumberName.Seventh => 7,
        };
#pragma warning restore CS8524 
    }
}
