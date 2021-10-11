using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music
{
    /// <summary>
    /// Contains functionality relating to the circle of fifths.
    /// </summary>
    public static class CircleOfFifths
    {
        /// <summary>
        /// Compares the two <see cref="SimpleInterval"/> values supplied in relation to their
        /// position on the circle of fifths.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static int CompareSimpleIntervals(SimpleInterval lhs, SimpleInterval rhs)
            => IntValue(lhs).CompareTo(IntValue(rhs));

        internal static int IntValue(SimpleInterval interval)
        {
            // Get the distance of the interval from perfect or major along the circle of
            // fifths to get the value
            int qualityIntValue, numberIntValue;
            switch (interval)
            {
                case PSimpleInterval(var quality, var number):
                    qualityIntValue = quality switch
                    {
                        DiminishedPIntervalQuality(var degree) => -degree,
                        PerfectIntervalQuality => 0,
                        AugmentedPIntervalQuality(var degree) => degree,
                    };

#pragma warning disable CS8524 // The SimpleInterval type doesn't allow unnamed enum values
                    numberIntValue = number switch
                    {
                        PSimpleIntervalNumberName.Unison => 0,
                        PSimpleIntervalNumberName.Fourth => -1,
                        PSimpleIntervalNumberName.Fifth => 1,
                    };
#pragma warning restore CS8524

                    break;

                case NPSimpleInterval(var quality, var number):
                    qualityIntValue = quality switch
                    {
                        DiminishedNPIntervalQuality(var degree) => -degree - 1,
                        MinorIntervalQuality => -1,
                        MajorIntervalQuality => 0,
                        AugmentedNPIntervalQuality(var degree) => degree,
                    };

#pragma warning disable CS8524 // The SimpleInterval type doesn't allow unnamed enum values
                    numberIntValue = number switch
                    {
                        NPSimpleIntervalNumberName.Second => 2,
                        NPSimpleIntervalNumberName.Third => 4,
                        NPSimpleIntervalNumberName.Sixth => 3,
                        NPSimpleIntervalNumberName.Seventh => 5,
                    };
#pragma warning restore CS8524

                    break;

                default:
                    // Should never happen
                    throw new NotImplementedException();
            }
            
            return numberIntValue + qualityIntValue * 7;
        }

        internal static SimpleInterval SimpleIntervalFromIntValue(int value)
        {
            // Get the number of a perfect or major interval that will share the number
            var numberIntValue = value % 7;

            // Need to ensure this value is positive
            if (numberIntValue < 0) numberIntValue += 7;

            // Need to treat a perfect fourth as negative
            if (numberIntValue == 6) numberIntValue = -1;

            // Need to treat the range [-1, 5] rather than the typical range of [0, 6]
            // used for modulo 7 so that a perfect fourth is negative, but perfect is always
            // treated as 0
            value++;

            // Need to ensure that the range [-7, -1] yields -1 instead of the range [-6, 0]
            // yielding 0, and so on and so forth
            var qualityIntValue = value < 0 ? (value + 1) / 7 - 1 : value / 7;

            switch (numberIntValue)
            {
                case -1 or 0 or 1:
#pragma warning disable CS8509 // Already ensured the integer is one of these values
                    var pNumberName = numberIntValue switch
                    {
                        -1 => PSimpleIntervalNumberName.Fourth,
                        0 => PSimpleIntervalNumberName.Unison,
                        1 => PSimpleIntervalNumberName.Fifth,
                    };
#pragma warning restore CS8509

                    PIntervalQuality pQuality = qualityIntValue switch
                    {
                        < 0 => new DiminishedPIntervalQuality(-qualityIntValue),
                        0 => new PerfectIntervalQuality(),
                        > 0 => new AugmentedPIntervalQuality(qualityIntValue),
                    };

                    return new PSimpleInterval(pQuality, pNumberName);

                default:
#pragma warning disable CS8509 // Integer must be between -1 and 5, inclusive
                    var npNumberName = numberIntValue switch
                    {
                        2 => NPSimpleIntervalNumberName.Second,
                        3 => NPSimpleIntervalNumberName.Sixth,
                        4 => NPSimpleIntervalNumberName.Third,
                        5 => NPSimpleIntervalNumberName.Seventh,
                    };
#pragma warning restore CS8509

                    NPIntervalQuality npQuality = qualityIntValue switch
                    {
                        -1 => new MinorIntervalQuality(),
                        0 => new MajorIntervalQuality(),
                        > 0 => new AugmentedNPIntervalQuality(qualityIntValue),
                        < 0 => new DiminishedNPIntervalQuality(-qualityIntValue - 1),
                    };

                    return new NPSimpleInterval(npQuality, npNumberName);
            }
        }
    }
}
