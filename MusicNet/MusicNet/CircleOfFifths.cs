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

        private static int IntValue(SimpleInterval interval)
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

                    numberIntValue = number switch
                    {
                        PSimpleIntervalNumberName.Unison => 0,
                        PSimpleIntervalNumberName.Fourth => -1,
                        PSimpleIntervalNumberName.Fifth => 1,
                    };

                    break;

                case NPSimpleInterval(var quality, var number):
                    qualityIntValue = quality switch
                    {
                        DiminishedNPIntervalQuality(var degree) => -degree - 1,
                        MinorIntervalQuality => -1,
                        MajorIntervalQuality => 0,
                        AugmentedNPIntervalQuality(var degree) => degree,
                    };

                    numberIntValue = number switch
                    {
                        NPSimpleIntervalNumberName.Second => 2,
                        NPSimpleIntervalNumberName.Third => 4,
                        NPSimpleIntervalNumberName.Sixth => 3,
                        NPSimpleIntervalNumberName.Seventh => 5,
                    };

                    break;

                default:
                    // Should never happen
                    throw new NotImplementedException();
            }
            
            return numberIntValue + qualityIntValue * 7;
        }
    }
}
