using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Notes
{
    /// <summary>
    /// Represents a note.
    /// </summary>
    /// <param name="Class">
    /// The note class of the note.
    /// </param>
    /// <param name="Octave">
    /// The octave of the note, corresponding to the standard music theory notation octave
    /// (with A4 having a frequency of 440 Hz).
    /// </param>
    public sealed record Note(NoteClass Class, int Octave)
    {
        /// <summary>
        /// Gets info about the pitch this note represents.
        /// </summary>
        public PitchInfo PitchInfo
        {
            get
            {
                // Get the pitch info for this note class
                // Needs to be based on 'C' since that is where octaves start
#pragma warning disable CS8524 // Note classes do not allow undefined note letter values
                var pitchClass = Class.Accidental + Class.Letter switch
#pragma warning restore CS8524
                {
                    NoteLetter.A => 9,
                    NoteLetter.B => 11,
                    NoteLetter.C => 0,
                    NoteLetter.D => 2,
                    NoteLetter.E => 4,
                    NoteLetter.F => 5,
                    NoteLetter.G => 7,
                };

                // Add overflow or underflow to the octave if there is one, and fix up the
                // pitch class if so
                var octaveAddition = pitchClass / 12;
                pitchClass %= 12;
                if (pitchClass < 0)
                {
                    octaveAddition--;
                    pitchClass += 12;
                }

                return new(Class: pitchClass, Octave: Octave + octaveAddition);
            }
        }

        /// <summary>
        /// Adds the interval passed in to the note passed in.
        /// </summary>
        /// <param name="note"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static Note operator +(Note note, Interval interval)
        {
            // Determine if there is an overflow
            var rawLetterCount = note.Class.Letter.OctaveIndex() + interval.Base.Number;
            var octaveOverflow = rawLetterCount / 7;
            return new Note(
                Class: note.Class + interval.Base,
                Octave: note.Octave + interval.Octaves + octaveOverflow);
        }

        /// <summary>
        /// Subtracts the interval passed in from the note passed in.
        /// </summary>
        /// <param name="note"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static Note operator -(Note note, Interval interval)
        {
            // Determine if there is an overflow
            var rawLetterCount = note.Class.Letter.OctaveIndex() - interval.Base.Number;
            var octaveOverflow = rawLetterCount / 7;
            
            // Fix up the octave overflow so this is the floor division
            if (rawLetterCount < 0) octaveOverflow--;

            return new Note(
                Class: note.Class - interval.Base,
                Octave: note.Octave - interval.Octaves + octaveOverflow);
        }
    }
}
