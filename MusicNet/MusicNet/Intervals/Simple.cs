using REMuns.Music.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Intervals
{
    /// <summary>
    /// Represents a perfectable simple interval.
    /// </summary>
    public sealed record PSimpleInterval(
        PIntervalQuality Quality, PSimpleIntervalNumberName NumberName)
    : SimpleInterval
    {
        /// <summary>
        /// The name of the number of this perfectable simple interval.
        /// </summary>
        public PSimpleIntervalNumberName NumberName
        {
            get => _numberName;
            init => _numberName = EnumChecks.EnsurePropNamed(value, nameof(NumberName));
        }
        private readonly PSimpleIntervalNumberName _numberName
            = EnumChecks.EnsureArgNamed(NumberName, nameof(NumberName));
    }

    /// <summary>
    /// Represents a non-perfectable simple interval.
    /// </summary>
    public sealed record NPSimpleInterval(
        NPIntervalQuality Quality, NPSimpleIntervalNumberName NumberName)
    : SimpleInterval
    {
        /// <summary>
        /// The name of the number of this non-perfectable simple interval.
        /// </summary>
        public NPSimpleIntervalNumberName NumberName
        {
            get => _numberName;
            init => _numberName = EnumChecks.EnsurePropNamed(value, nameof(NumberName));
        }
        private readonly NPSimpleIntervalNumberName _numberName
            = EnumChecks.EnsureArgNamed(NumberName, nameof(NumberName));
    }

    /// <summary>
    /// Represents a simple musical interval (less than an octave in number).
    /// </summary>
    public abstract record SimpleInterval
    {
        /// <summary>
        /// Creates an object that can build a diminished simple interval with the
        /// predefined degree.
        /// </summary>
        /// <param name="Degree"></param>
        /// <returns></returns>
        public static DiminishedSimpleIntervalBuilder Diminished(int Degree)
            => new() { Degree = Degree };

        /// <summary>
        /// Creates an object that can build a minor simple interval.
        /// </summary>
        /// <returns></returns>
        public static NPSimpleIntervalBuilder Minor()
            => new() { Quality = new MinorIntervalQuality() };

        /// <summary>
        /// Creates an object that can build a perfect simple interval.
        /// </summary>
        /// <returns></returns>
        public static PSimpleIntervalBuilder Perfect()
            => new() { Quality = new PerfectIntervalQuality() };

        /// <summary>
        /// Creates an object that can build a major simple interval.
        /// </summary>
        /// <returns></returns>
        public static NPSimpleIntervalBuilder Major()
            => new() { Quality = new MajorIntervalQuality() };

        /// <summary>
        /// Creates an object that can build an augmented simple interval with the
        /// predefined degree.
        /// </summary>
        /// <param name="Degree"></param>
        /// <returns></returns>
        public static AugmentedSimpleIntervalBuilder Augmented(int Degree)
            => new() { Degree = Degree };
    }
}
