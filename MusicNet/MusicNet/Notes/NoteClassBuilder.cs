using REMuns.Music.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Notes
{
    /// <summary>
    /// An object that can build a <see cref="NoteClass"/> with a
    /// predefined <see cref="NoteLetter"/>.
    /// </summary>
    public readonly struct NoteClassBuilder
    {
        /// <summary>
        /// The note letter to assign to the <see cref="NoteClass"/> being constructed.
        /// </summary>
        public NoteLetter Letter { get; init; }

        /// <summary>
        /// Constructs a new <see cref="NoteClass"/> with the predefined note letter and the
        /// given sharp degree.
        /// </summary>
        /// <param name="Degree"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="Degree"/> was non-positive.
        /// </exception>
        public NoteClass Sharp(int Degree = 1)
            => new(Letter, IntChecks.EnsureArgPositive(Degree, nameof(Degree)));

        /// <summary>
        /// Constructs a new <see cref="NoteClass"/> with the predefined note letter and a
        /// natural accidental.
        /// </summary>
        /// <returns></returns>
        public NoteClass Natural() => new(Letter);

        /// <summary>
        /// Constructs a new <see cref="NoteClass"/> with the predefined note letter and the
        /// given flat degree.
        /// </summary>
        /// <param name="Degree"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="Degree"/> was non-positive.
        /// </exception>
        public NoteClass Flat(int Degree = 1)
            => new(Letter, -IntChecks.EnsureArgPositive(Degree, nameof(Degree)));

        /// <summary>
        /// Implicitly converts a <see cref="NoteClassBuilder"/> to a natural note with the
        /// letter it wraps.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator NoteClass(NoteClassBuilder builder) => new(builder.Letter);
    }
}
