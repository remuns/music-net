using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.Music.Intervals;
using REMuns.Music.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music.Test.Notes
{
    /// <summary>
    /// Tests for the <see cref="Note"/> record.
    /// </summary>
    [TestClass]
    public class NoteTest
    {
        /// <summary>
        /// Tests the <see cref="Note.PitchInfo"/> property.
        /// </summary>
        [TestMethod]
        public void TestPitchInfo()
        {
            // A440
            Assert.AreEqual(new(Class: 9, Octave: 4), new Note(NoteClass.A(), 4).PitchInfo);

            // Test overflows and underflows
            Assert.AreEqual(new(Class: 11, Octave: 3), new Note(NoteClass.C().Flat(), 4).PitchInfo);
            Assert.AreEqual(new(Class: 0, Octave: 2), new Note(NoteClass.B().Sharp(), 1).PitchInfo);
        }

        /// <summary>
        /// Tests addition of an interval to a note.
        /// </summary>
        [TestMethod]
        public void TestIntervalAddition()
        {
            Assert.AreEqual(
                new Note(NoteClass.A(), 3),
                new Note(NoteClass.G(), 2) + new Interval(SimpleInterval.Major().Second(), 1));

            // Overflows
            Assert.AreEqual(
                new Note(NoteClass.E(), 5),
                new Note(NoteClass.B(), 3) + new Interval(SimpleInterval.Perfect().Fourth(), 1));
        }

        /// <summary>
        /// Tests subtraction of an interval from a note.
        /// </summary>
        [TestMethod]
        public void TestIntervalSubtraction()
        {
            Assert.AreEqual(
                new Note(NoteClass.F(), 3),
                new Note(NoteClass.A(), 5) - new Interval(SimpleInterval.Major().Third(), 2));

            // Underflows
            Assert.AreEqual(
                new Note(NoteClass.A().Flat(), 3),
                new Note(NoteClass.D(), 5) - new Interval(SimpleInterval.Augmented().Fourth(), 1));
        }

        /// <summary>
        /// Tests difference between two notes.
        /// </summary>
        [TestMethod]
        public void TestNoteDifference()
        {
            Assert.AreEqual(
                DirectedInterval.Down(SimpleInterval.Minor().Third()),
                new Note(NoteClass.A(), 4) - new Note(NoteClass.C(), 5));

            Assert.AreEqual(
                DirectedInterval.Down(new Interval(SimpleInterval.Major().Sixth(), 1)),
                new Note(NoteClass.C(), 4) - new Note(NoteClass.A(), 5));

            Assert.AreEqual(
                DirectedInterval.Up(new Interval(SimpleInterval.Perfect().Fifth(), 1)),
                new Note(NoteClass.B(), 5) - new Note(NoteClass.E(), 4));

            Assert.AreEqual(
                DirectedInterval.Up(SimpleInterval.Perfect().Fourth()),
                new Note(NoteClass.E(), 5) - new Note(NoteClass.B(), 4));

            Assert.AreEqual(
                DirectedInterval.Up(SimpleInterval.Augmented().Unison()),
                new Note(NoteClass.C(), 3) - new Note(NoteClass.C().Flat(), 3));
        }
    }
}
