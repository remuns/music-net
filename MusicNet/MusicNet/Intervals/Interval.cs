﻿using REMuns.Music.Internal;
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
        public bool IsSimple => Octave == 0;

        /// <summary>
        /// Gets whether or not this interval represents a compound interval (i.e. has an octave
        /// offset that is greater than 0).
        /// </summary>
        public bool IsCompound => Octave != 0;

        /// <summary>
        /// The number of octaves offset from the base simple interval.
        /// </summary>
        public int Octave
        {
            get => _octave;
            init => _octave = IntChecks.EnsurePropNonNegative(value, nameof(Octave));
        }
        private readonly int _octave = IntChecks.EnsureArgNonNegative(Octave, nameof(Octave));
    }
}
