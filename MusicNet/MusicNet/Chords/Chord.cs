using REMuns.Music.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REMuns.Music.Chords
{
    /// <summary>
    /// Represents a chord.
    /// </summary>
    /// <param name="Root"></param>
    /// <param name="Schema"></param>
    public sealed record Chord(NoteClass Root, IChordSchema Schema)
    {
        /// <summary>
        /// Gets the base note class of the chord.
        /// </summary>
        public NoteClass Base => NoteClasses.First();

        /// <summary>
        /// Gets the note classes of the chord.
        /// </summary>
        public IEnumerable<NoteClass> NoteClasses
        {
            get
            {
                if (Schema is InversionChordSchema ics)
                {
                    // Handle the inversion properly by separating the base from the root
                    var baseNote = Root - ics.Root;

                    foreach (var interval in ics.Intervals)
                    {
                        yield return baseNote + interval;
                    }
                }
                else
                {
                    foreach (var interval in Schema.Intervals)
                    {
                        yield return Root + interval;
                    }
                }
            }
        }
    }
}
