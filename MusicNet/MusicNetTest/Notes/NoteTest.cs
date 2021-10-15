using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
