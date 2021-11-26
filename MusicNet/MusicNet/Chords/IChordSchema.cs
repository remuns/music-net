using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Chords
{
    /// <summary>
    /// Represents a series of simple intervals that define a schema for a chord.
    /// </summary>
    public interface IChordSchema
    {
        /// <summary>
        /// The simple intervals this chord schema is comprised of.
        /// </summary>
        public IEnumerable<SimpleInterval> Intervals { get; }

        /// <summary>
        /// The number of intervals included in this chord.
        /// </summary>
        public int IntervalCount { get; }
    }
}
