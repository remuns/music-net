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
        PIntervalQuality Quality, SimplePIntervalNumberName NumberName)
    : SimpleInterval
    {
        /// <summary>
        /// The name of the number of this perfectable simple interval.
        /// </summary>
        public SimplePIntervalNumberName NumberName
        {
            get => _numberName;
            init => _numberName = EnumChecks.EnsurePropNamed(value, nameof(NumberName));
        }
        private readonly SimplePIntervalNumberName _numberName
            = EnumChecks.EnsureArgNamed(NumberName, nameof(NumberName));
    }

    /// <summary>
    /// Represents a non-perfectable simple interval.
    /// </summary>
    public sealed record NPSimpleInterval(
        PIntervalQuality Quality, SimpleNPIntervalNumberName NumberName)
    : SimpleInterval
    {
        /// <summary>
        /// The name of the number of this non-perfectable simple interval.
        /// </summary>
        public SimpleNPIntervalNumberName NumberName
        {
            get => _numberName;
            init => _numberName = EnumChecks.EnsurePropNamed(value, nameof(NumberName));
        }
        private readonly SimpleNPIntervalNumberName _numberName
            = EnumChecks.EnsureArgNamed(NumberName, nameof(NumberName));
    }

    /// <summary>
    /// Represents a simple interval (less than an octave in number).
    /// </summary>
    public abstract record SimpleInterval;
}
