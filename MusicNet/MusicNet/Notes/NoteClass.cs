using REMuns.Music.Internal;
using REMuns.Music.Intervals;
using REMuns.Music.Scales;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Notes
{
    /// <summary>
    /// Represents a class of notes, ignoring octaves.
    /// </summary>
    public readonly record struct NoteClass(NoteLetter Letter, int Accidental = 0)
    {
        /// <summary>
        /// Gets whether or not this note is sharp.
        /// </summary>
        public bool IsSharp => Accidental > 0;

        /// <summary>
        /// Gets whether or not this note is natural.
        /// </summary>
        public bool IsNatural => Accidental == 0;

        /// <summary>
        /// Gets whether or not this note is flat.
        /// </summary>
        public bool IsFlat => Accidental < 0;

        /// <summary>
        /// The letter of the note class this object represents.
        /// </summary>
        public NoteLetter Letter
        {
            get => _letter;
            init => _letter = EnumChecks.EnsureArgNamed(Letter, nameof(Letter));
        }
        private readonly NoteLetter _letter = EnumChecks.EnsureArgNamed(Letter, nameof(Letter));

        /// <summary>
        /// Adds the simple interval passed in to the note class passed in, ignoring octaves.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static NoteClass operator +(NoteClass lhs, SimpleInterval rhs)
            => CircleOfFifths.NoteClassFromIntValue(
                CircleOfFifths.IntValue(lhs) + CircleOfFifths.IntValue(rhs));

        /// <summary>
        /// Subtracts the simple interval passed in from the note class passed in,
        /// ignoring octaves.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static NoteClass operator -(NoteClass lhs, SimpleInterval rhs)
            => CircleOfFifths.NoteClassFromIntValue(
                CircleOfFifths.IntValue(lhs) - CircleOfFifths.IntValue(rhs));

        /// <summary>
        /// Finds the difference between the note classes passed in as a
        /// <see cref="SimpleInterval"/>, ignoring octaves.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static SimpleInterval operator -(NoteClass lhs, NoteClass rhs)
            => CircleOfFifths.SimpleIntervalFromIntValue(
                CircleOfFifths.IntValue(lhs) - CircleOfFifths.IntValue(rhs));

        /// <summary>
        /// Constructs a new Lydian mode with the current instance as the root.
        /// </summary>
        /// <returns></returns>
        public StandardMode Lydian() => new(this, StandardModeType.Lydian);

        /// <summary>
        /// Constructs a new Ionian mode with the current instance as the root.
        /// </summary>
        /// <returns></returns>
        public StandardMode Ionian() => new(this, StandardModeType.Ionian);

        /// <summary>
        /// Constructs a new Mixolydian mode with the current instance as the root.
        /// </summary>
        /// <returns></returns>
        public StandardMode Mixolydian() => new(this, StandardModeType.Mixolydian);

        /// <summary>
        /// Constructs a new Dorian mode with the current instance as the root.
        /// </summary>
        /// <returns></returns>
        public StandardMode Dorian() => new(this, StandardModeType.Dorian);

        /// <summary>
        /// Constructs a new Aeolian mode with the current instance as the root.
        /// </summary>
        /// <returns></returns>
        public StandardMode Aeolian() => new(this, StandardModeType.Aeolian);

        /// <summary>
        /// Constructs a new Phrygian mode with the current instance as the root.
        /// </summary>
        /// <returns></returns>
        public StandardMode Phrygian() => new(this, StandardModeType.Phrygian);

        /// <summary>
        /// Constructs a new Locrian mode with the current instance as the root.
        /// </summary>
        /// <returns></returns>
        public StandardMode Locrian() => new(this, StandardModeType.Locrian);

        /// <summary>
        /// Gets a builder object that can be used to construct an 'A' note with a
        /// given accidental.
        /// </summary>
        /// <returns></returns>
        public static NoteClassBuilder A() => new() { Letter = NoteLetter.A };

        /// <summary>
        /// Gets a builder object that can be used to construct a 'B' note with a
        /// given accidental.
        /// </summary>
        /// <returns></returns>
        public static NoteClassBuilder B() => new() { Letter = NoteLetter.B };

        /// <summary>
        /// Gets a builder object that can be used to construct a 'C' note with a
        /// given accidental.
        /// </summary>
        /// <returns></returns>
        public static NoteClassBuilder C() => new() { Letter = NoteLetter.C };

        /// <summary>
        /// Gets a builder object that can be used to construct a 'D' note with a
        /// given accidental.
        /// </summary>
        /// <returns></returns>
        public static NoteClassBuilder D() => new() { Letter = NoteLetter.D };

        /// <summary>
        /// Gets a builder object that can be used to construct an 'E' note with a
        /// given accidental.
        /// </summary>
        /// <returns></returns>
        public static NoteClassBuilder E() => new() { Letter = NoteLetter.E };

        /// <summary>
        /// Gets a builder object that can be used to construct an 'F' note with a
        /// given accidental.
        /// </summary>
        /// <returns></returns>
        public static NoteClassBuilder F() => new() { Letter = NoteLetter.F };

        /// <summary>
        /// Gets a builder object that can be used to construct a 'G' note with a
        /// given accidental.
        /// </summary>
        /// <returns></returns>
        public static NoteClassBuilder G() => new() { Letter = NoteLetter.G };
    }
}
