using REMuns.Music.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Intervals
{
    /// <summary>
    /// Represents a musical interval.
    /// </summary>
    public sealed record Interval(SimpleInterval Base, int Octave)
    {
        /// <summary>
        /// Gets whether or not this interval represents a simple interval (i.e. has an octave
        /// offset of 0).
        /// </summary>
        public bool IsSimple => Octaves == 0;

        /// <summary>
        /// Gets whether or not this interval represents a compound interval (i.e. has an octave
        /// offset that is greater than 0).
        /// </summary>
        public bool IsCompound => Octaves != 0;

        /// <summary>
        /// The number of octaves offset from the base simple interval.
        /// </summary>
        public int Octaves
        {
            get => _octave;
            init => _octave = IntChecks.EnsurePropNonNegative(value, nameof(Octaves));
        }
        private readonly int _octave = IntChecks.EnsureArgNonNegative(Octave, nameof(Octave));

        /// <summary>
        /// Gets an <see cref="Interval"/> equivalent to this one with the specified number
        /// of octaves added.
        /// </summary>
        /// <param name="octaves"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// The result of the addition would yield a negative number of octaves.
        /// </exception>
        public Interval WithOctavesAdded(int octaves)
        {
            return this with { Octaves = Octaves + octaves };
        }

        /// <summary>
        /// Implicitly converts a <see cref="SimpleInterval"/> to an <see cref="Interval"/>.
        /// </summary>
        /// <param name="s"></param>
        public static implicit operator Interval(SimpleInterval s) => new(s, 0);
    }
}
