using REMuns.Music.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Notes
{
    /// <summary>
    /// Represents the letter name of a note.
    /// </summary>
    public enum NoteLetter : byte
    {
        /// <summary>
        /// Represents an 'A' note.
        /// </summary>
        A,

        /// <summary>
        /// Represents a 'B' note.
        /// </summary>
        B,

        /// <summary>
        /// Represents a 'C' note.
        /// </summary>
        C,

        /// <summary>
        /// Represents a 'D' note.
        /// </summary>
        D,

        /// <summary>
        /// Represents an 'E' note.
        /// </summary>
        E,

        /// <summary>
        /// Represents an 'F' note.
        /// </summary>
        F,

        /// <summary>
        /// Represents a 'G' note.
        /// </summary>
        G,
    }

    /// <summary>
    /// Static functionality for the <see cref="NoteLetter"/> enum.
    /// </summary>
    public static class NoteLetters
    {
        /// <summary>
        /// Gets the index of this note letter in an octave relative to 'C'.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public static int OctaveIndex(this NoteLetter letter)
            => EnumChecks.EnsureArgNamed(letter, nameof(letter)) switch
            {
                NoteLetter.A => 5,
                NoteLetter.B => 6,
                NoteLetter.C => 0,
                NoteLetter.D => 1,
                NoteLetter.E => 2,
                NoteLetter.F => 3,
                NoteLetter.G => 4,
            };
    }
}
