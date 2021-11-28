using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REMuns.Music.Chords
{
    /// <summary>
    /// Represents an inversion of a root position chord schema.
    /// </summary>
    public sealed class InversionChordSchema : IChordSchema, IEquatable<InversionChordSchema>
    {
        /// <summary>
        /// The inversion of the root position this object represents.
        /// </summary>
        public int Inversion { get; }

        /// <summary>
        /// The root position chord being inverted.
        /// </summary>
        public IRootPositionChordSchema RootPosition { get; }

        /// <summary>
        /// Gets the simple intervals that comprise the inversion.
        /// </summary>
        public IEnumerable<SimpleInterval> Intervals
        {
            get
            {
                var shiftedIntervals = RootPosition.Intervals.Skip(Inversion);
                var baseInterval = shiftedIntervals.First();
                
                foreach (var si in shiftedIntervals)
                {
                    yield return si - baseInterval;
                }

                foreach (var ti in RootPosition.Intervals.Take(Inversion))
                {
                    yield return ti - baseInterval;
                }
            }
        }

        /// <summary>
        /// Gets the count of the intervals in the wrapped root position chord.
        /// </summary>
        public int IntervalCount => RootPosition.IntervalCount;

        /// <summary>
        /// Gets whether or not this chord is in root position.
        /// </summary>
        public bool IsRootPosition => Inversion == 0;

        /// <summary>
        /// Gets whether or not this chord is inverted (i.e. in non-root position).
        /// </summary>
        public bool IsInverted => Inversion != 0;

        /// <summary>
        /// Gets the root of the chord schema.
        /// </summary>
        public SimpleInterval Root => Intervals.ElementAt((IntervalCount - Inversion) % IntervalCount);

        /// <summary>
        /// Constructs a new instance of the <see cref="InversionChordSchema"/> class with the root
        /// position chord and inversion passed in.
        /// </summary>
        /// <param name="RootPosition"></param>
        /// <param name="Inversion"></param>
        /// <exception cref="ArgumentException">
        /// The inversion number is negative or out of range of the number of intervals in
        /// the chord.
        /// </exception>
        public InversionChordSchema(IRootPositionChordSchema RootPosition, int Inversion)
        {
            this.RootPosition = RootPosition;
            
            if (Inversion < 0 || Inversion >= RootPosition.IntervalCount)
            {
                throw new ArgumentException($"inversion {Inversion} is out of range");
            }
            this.Inversion = Inversion;
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(InversionChordSchema other)
        {
            return this.Inversion == other.Inversion &&
                    this.RootPosition.Equals(other.RootPosition);
        }
    }
}
