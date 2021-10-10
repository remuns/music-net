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
        PIntervalQuality Quality, NPSimpleIntervalNumberName NumberName)
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
    public abstract record SimpleInterval;
}
