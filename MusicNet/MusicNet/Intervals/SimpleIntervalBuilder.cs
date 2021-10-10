using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Intervals
{
    /// <summary>
    /// A struct that builds a perfectable simple interval from a predefined quality.
    /// </summary>
    public readonly struct PSimpleIntervalBuilder
    {
        /// <summary>
        /// The quality to use to build the perfectable simple interval.
        /// </summary>
        public PIntervalQuality Quality { get; init; }

        /// <summary>
        /// Builds a unison with the predefined quality.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Unison() => new(Quality, PSimpleIntervalNumberName.Unison);

        /// <summary>
        /// Builds a fourth with the predefined quality.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Fourth() => new(Quality, PSimpleIntervalNumberName.Fourth);

        /// <summary>
        /// Builds a fifth with the predefined quality.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Fifth() => new(Quality, PSimpleIntervalNumberName.Fifth);
    }

    /// <summary>
    /// A struct that builds a non-perfectable simple interval from a predefined quality.
    /// </summary>
    public readonly struct NPSimpleIntervalBuilder
    {
        /// <summary>
        /// The quality to use to build the non-perfectable simple interval.
        /// </summary>
        public NPIntervalQuality Quality { get; init; }

        /// <summary>
        /// Builds a second with the predefined quality.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Second() => new(Quality, NPSimpleIntervalNumberName.Second);

        /// <summary>
        /// Builds a third with the predefined quality.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Third() => new(Quality, NPSimpleIntervalNumberName.Third);

        /// <summary>
        /// Builds a sixth with the predefined quality.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Sixth() => new(Quality, NPSimpleIntervalNumberName.Sixth);

        /// <summary>
        /// Builds a seventh with the predefined quality.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Seventh() => new(Quality, NPSimpleIntervalNumberName.Seventh);
    }

    /// <summary>
    /// A struct that builds a diminished simple interval with a predefined degree.
    /// </summary>
    public readonly struct DiminishedSimpleIntervalBuilder
    {
        /// <summary>
        /// The diminished degree with which to build the simple interval.
        /// </summary>
        public int Degree { get; init; }

        /// <summary>
        /// Builds a unison with a diminished quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Unison()
            => new(new DiminishedPIntervalQuality(Degree), PSimpleIntervalNumberName.Unison);

        /// <summary>
        /// Builds a second with a diminished quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Second()
            => new(new DiminishedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Second);

        /// <summary>
        /// Builds a third with a diminished quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Third()
            => new(new DiminishedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Third);

        /// <summary>
        /// Builds a fourth with a diminished quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Fourth()
            => new(new DiminishedPIntervalQuality(Degree), PSimpleIntervalNumberName.Fourth);

        /// <summary>
        /// Builds a fifth with a diminished quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Fifth()
            => new(new DiminishedPIntervalQuality(Degree), PSimpleIntervalNumberName.Fifth);

        /// <summary>
        /// Builds a sixth with a diminished quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Sixth()
            => new(new DiminishedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Sixth);

        /// <summary>
        /// Builds a seventh with a diminished quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Seventh()
            => new(new DiminishedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Seventh);
    }

    /// <summary>
    /// A struct that builds an augmented simple interval with a predefined degree.
    /// </summary>
    public readonly struct AugmentedSimpleIntervalBuilder
    {
        /// <summary>
        /// The augmented degree with which to build the simple interval.
        /// </summary>
        public int Degree { get; init; }

        /// <summary>
        /// Builds a unison with an augmented quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Unison()
            => new(new AugmentedPIntervalQuality(Degree), PSimpleIntervalNumberName.Unison);

        /// <summary>
        /// Builds a second with an augmented quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Second()
            => new(new AugmentedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Second);

        /// <summary>
        /// Builds a third with an augmented quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Third()
            => new(new AugmentedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Third);

        /// <summary>
        /// Builds a fourth with an augmented quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Fourth()
            => new(new AugmentedPIntervalQuality(Degree), PSimpleIntervalNumberName.Fourth);

        /// <summary>
        /// Builds a fifth with an augmented quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public PSimpleInterval Fifth()
            => new(new AugmentedPIntervalQuality(Degree), PSimpleIntervalNumberName.Fifth);

        /// <summary>
        /// Builds a sixth with an augmented quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Sixth()
            => new(new AugmentedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Sixth);

        /// <summary>
        /// Builds a seventh with an augmented quality of the predefined degree.
        /// </summary>
        /// <returns></returns>
        public NPSimpleInterval Seventh()
            => new(new AugmentedNPIntervalQuality(Degree), NPSimpleIntervalNumberName.Seventh);
    }
}
