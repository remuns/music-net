using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.Music.Chords;
using REMuns.Music.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music.Test.Chords
{
    /// <summary>
    /// Tests for the <see cref="Chord"/> record.
    /// </summary>
    [TestClass]
    public class ChordTest
    {
        /// <summary>
        /// Tests that the <see cref="Chord.NoteClasses"/> returns the note classes of the chord
        /// in the correct order.
        /// </summary>
        [TestMethod]
        public void TestNoteClasses()
        {
            var rootPosChord = new Chord(NoteClass.A(), TriadSchema.Major);
            Assert.IsTrue(
                new[] { NoteClass.A(), NoteClass.C().Sharp(), NoteClass.E() }
                    .SequenceEqual(rootPosChord.NoteClasses));

            var invertedChord = new Chord(
                NoteClass.C(), new InversionChordSchema(TriadSchema.Minor, 1));
            Assert.IsTrue(
                new[] { NoteClass.E().Flat(), NoteClass.G(), NoteClass.C() }
                    .SequenceEqual(invertedChord.NoteClasses));
        }
    }
}
