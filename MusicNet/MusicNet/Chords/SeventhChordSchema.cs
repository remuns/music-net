using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Chords
{
    /// <summary>
    /// Represents a schema for a seventh chord.
    /// </summary>
    /// <param name="ThirdQuality"></param>
    /// <param name="FifthQuality"></param>
    /// <param name="SeventhQuality"></param>
    public sealed record SeventhChordSchema(
        NPIntervalQuality ThirdQuality, PIntervalQuality FifthQuality, NPIntervalQuality SeventhQuality)
        : IRootPositionChordSchema
    {
        /// <summary>
        /// A fully diminished seventh chord schema.
        /// </summary>
        public static readonly SeventhChordSchema Diminished = new(
            new MinorIntervalQuality(), new DiminishedPIntervalQuality(1), new DiminishedNPIntervalQuality(1));

        /// <summary>
        /// A half diminished seventh chord schema.
        /// </summary>
        public static readonly SeventhChordSchema HalfDiminished = new(
            new MinorIntervalQuality(), new DiminishedPIntervalQuality(1), new MinorIntervalQuality());

        /// <summary>
        /// A minor seventh chord schema.
        /// </summary>
        public static readonly SeventhChordSchema Minor = new(
            new MinorIntervalQuality(), new PerfectIntervalQuality(), new MinorIntervalQuality());

        /// <summary>
        /// A major-minor (dominant) seventh chord schema.
        /// </summary>
        public static readonly SeventhChordSchema MajorMinor = new(
            new MajorIntervalQuality(), new PerfectIntervalQuality(), new MinorIntervalQuality());

        /// <summary>
        /// A major seventh chord schema.
        /// </summary>
        public static readonly SeventhChordSchema Major = new(
            new MajorIntervalQuality(), new PerfectIntervalQuality(), new MajorIntervalQuality());

        /// <summary>
        /// An augmented seventh chord schema.
        /// </summary>
        public static readonly SeventhChordSchema Augmented = new(
            new MajorIntervalQuality(), new AugmentedPIntervalQuality(1), new MajorIntervalQuality());

        public IEnumerable<SimpleInterval> Intervals
        {
            get
            {
                yield return SimpleInterval.Perfect().Unison();
                yield return new NPSimpleInterval(ThirdQuality, NPSimpleIntervalNumberName.Third);
                yield return new PSimpleInterval(FifthQuality, PSimpleIntervalNumberName.Fifth);
                yield return new NPSimpleInterval(SeventhQuality, NPSimpleIntervalNumberName.Seventh);
            }
        }

        /// <inheritdoc cref="IChordSchema.IntervalCount"/>
        public int IntervalCount => 4;
    }
}
