using REMuns.Music.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Intervals
{
    #region PIntervals
    /// <summary>
    /// Represents a diminished quality of a perfectable interval.
    /// </summary>
    public sealed record DiminishedPIntervalQuality(int Degree) : PIntervalQuality
    {
        /// <summary>
        /// The degree of this diminished interval quality.
        /// </summary>
        public int Degree
        {
            get => _degree;
            init => _degree = IntChecks.EnsurePropPositive(value, nameof(Degree));
        }
        private readonly int _degree = IntChecks.EnsureArgPositive(Degree, nameof(Degree));
    }

    /// <summary>
    /// Represents a perfect interval quality.
    /// </summary>
    public sealed record PerfectIntervalQuality : PIntervalQuality;

    /// <summary>
    /// Represents an augmented quality of a perfectable interval.
    /// </summary>
    public sealed record AugmentedPIntervalQuality(int Degree) : PIntervalQuality
    {
        /// <summary>
        /// The degree of this augmented interval quality.
        /// </summary>
        public int Degree
        {
            get => _degree;
            init => _degree = IntChecks.EnsurePropPositive(value, nameof(Degree));
        }
        private readonly int _degree = IntChecks.EnsureArgPositive(Degree, nameof(Degree));
    }

    /// <summary>
    /// Represents the quality of a perfectable interval.
    /// </summary>
    public abstract record PIntervalQuality : IntervalQuality;
    #endregion

    #region NPIntervals
    /// <summary>
    /// Represents a diminished quality of a non-perfectable interval.
    /// </summary>
    public sealed record DiminishedNPIntervalQuality(int Degree) : NPIntervalQuality
    {
        /// <summary>
        /// The degree of this diminished interval quality.
        /// </summary>
        public int Degree
        {
            get => _degree;
            init => _degree = IntChecks.EnsurePropPositive(value, nameof(Degree));
        }
        private readonly int _degree = IntChecks.EnsureArgPositive(Degree, nameof(Degree));
    }

    /// <summary>
    /// Represents a minor interval quality.
    /// </summary>
    public sealed record MinorIntervalQuality : NPIntervalQuality;

    /// <summary>
    /// Represents a major interval quality.
    /// </summary>
    public sealed record MajorIntervalQuality : NPIntervalQuality;

    /// <summary>
    /// Represents an augmented quality of a non-perfectable interval.
    /// </summary>
    public sealed record AugmentedNPIntervalQuality(int Degree) : NPIntervalQuality
    {
        /// <summary>
        /// The degree of this augmented interval quality.
        /// </summary>
        public int Degree
        {
            get => _degree;
            init => _degree = IntChecks.EnsurePropPositive(value, nameof(Degree));
        }
        private readonly int _degree = IntChecks.EnsureArgPositive(Degree, nameof(Degree));
    }

    /// <summary>
    /// Represents the quality of a non-perfectable interval.
    /// </summary>
    public abstract record NPIntervalQuality : IntervalQuality;
    #endregion

    /// <summary>
    /// Represents the quality of an interval.
    /// </summary>
    public abstract record IntervalQuality;
}
