using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Chords
{
    /// <summary>
    /// Represents a schema for a triad.
    /// </summary>
    /// <param name="ThirdQuality"></param>
    /// <param name="FifthQuality"></param>
    public sealed record TriadSchema(NPIntervalQuality ThirdQuality, PIntervalQuality FifthQuality) : IRootPositionChordSchema
    {
        /// <summary>
        /// A diminished triad schema.
        /// </summary>
        public static readonly TriadSchema Diminished = new(new MinorIntervalQuality(), new DiminishedPIntervalQuality(1));

        /// <summary>
        /// A minor triad schema.
        /// </summary>
        public static readonly TriadSchema Minor = new(new MinorIntervalQuality(), new PerfectIntervalQuality());

        /// <summary>
        /// A major triad schema.
        /// </summary>
        public static readonly TriadSchema Major = new(new MajorIntervalQuality(), new PerfectIntervalQuality());

        /// <summary>
        /// An augmented triad schema.
        /// </summary>
        public static readonly TriadSchema Augmented = new(new MajorIntervalQuality(), new AugmentedPIntervalQuality(1));

        /// <summary>
        /// Gets the intervals comprising this triad.
        /// </summary>
        public IEnumerable<SimpleInterval> Intervals
        {
            get
            {
                yield return SimpleInterval.Perfect().Unison();
                yield return new NPSimpleInterval(ThirdQuality, NPSimpleIntervalNumberName.Third);
                yield return new PSimpleInterval(FifthQuality, PSimpleIntervalNumberName.Fifth);
            }
        }

        /// <inheritdoc cref="IChordSchema.IntervalCount"/>
        public int IntervalCount => 3;
    }
}
