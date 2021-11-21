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
        private protected override IntervalQuality InternalQuality => Quality;

        /// <inheritdoc cref="SimpleInterval.Quality"/>
        public new PIntervalQuality Quality
        {
            get => _quality;
            init => _quality = value;
        }
        private readonly PIntervalQuality _quality = Quality;

        /// <inheritdoc cref="SimpleInterval.Number"/>
        public override int Number => (int)NumberName;

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

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"SimpleInterval({Quality}, {NumberName})";
    }

    /// <summary>
    /// Represents a non-perfectable simple interval.
    /// </summary>
    public sealed record NPSimpleInterval(
        NPIntervalQuality Quality, NPSimpleIntervalNumberName NumberName)
    : SimpleInterval
    {
        private protected override IntervalQuality InternalQuality => Quality;

        /// <inheritdoc cref="SimpleInterval.Quality"/>
        public new NPIntervalQuality Quality
        {
            get => _quality;
            init => _quality = value;
        }
        private readonly NPIntervalQuality _quality = Quality;

        /// <inheritdoc cref="SimpleInterval.Number"/>
        public override int Number => (int)NumberName;

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

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"SimpleInterval({Quality}, {NumberName})";
    }

    /// <summary>
    /// Represents a simple musical interval (less than an octave in number).
    /// </summary>
    public abstract record SimpleInterval
    {
        /// <summary>
        /// The number of this simple interval.
        /// </summary>
        public abstract int Number { get; }

        /// <summary>
        /// The quality of this simple interval.
        /// </summary>
        public IntervalQuality Quality => InternalQuality;

        /// <summary>
        /// Represents the quality of an interval internally, so that subrecords can store
        /// qualities of the correct type.
        /// </summary>
        private protected abstract IntervalQuality InternalQuality { get; }

        /// <summary>
        /// Creates an object that can build a diminished simple interval with the
        /// predefined degree.
        /// </summary>
        /// <param name="Degree"></param>
        /// <returns></returns>
        public static DiminishedSimpleIntervalBuilder Diminished(int Degree = 1)
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
        public static AugmentedSimpleIntervalBuilder Augmented(int Degree = 1)
            => new() { Degree = Degree };

        /// <summary>
        /// Finds the simple interval separating the two simple intervals, ignoring octaves.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static SimpleInterval operator +(SimpleInterval lhs, SimpleInterval rhs)
            => CircleOfFifths.SimpleIntervalFromIntValue(
                CircleOfFifths.IntValue(lhs) + CircleOfFifths.IntValue(rhs));

        /// <summary>
        /// Finds the simple interval separating the two simple intervals, ignoring octaves.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static SimpleInterval operator -(SimpleInterval lhs, SimpleInterval rhs)
            => CircleOfFifths.SimpleIntervalFromIntValue(
                CircleOfFifths.IntValue(lhs) - CircleOfFifths.IntValue(rhs));

        /// <summary>
        /// Gets an interval equal to this one, but inverted.
        /// </summary>
        /// <returns></returns>
        public SimpleInterval Inverted()
            => CircleOfFifths.SimpleIntervalFromIntValue(-CircleOfFifths.IntValue(this));
    }
}
