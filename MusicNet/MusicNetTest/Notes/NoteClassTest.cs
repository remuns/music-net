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
    [TestClass]
    public class NoteClassTest
    {
        /// <summary>
        /// Tests adding a simple interval to a note class.
        /// </summary>
        [TestMethod]
        public void TestIntervalAddition()
        {
            Assert.AreEqual(
                NoteClass.A().Natural(),
                NoteClass.C().Natural() + SimpleInterval.Major().Sixth());

            // Adding a perfect unison should have no effect
            Assert.AreEqual(
                NoteClass.F().Sharp(),
                NoteClass.F().Sharp() + SimpleInterval.Perfect().Unison());

            Assert.AreEqual(
                NoteClass.A().Flat(),
                NoteClass.E().Flat() + SimpleInterval.Perfect().Fourth());

            Assert.AreEqual(
                NoteClass.C().Sharp(),
                NoteClass.C().Natural() + SimpleInterval.Augmented().Unison());

            Assert.AreEqual(
                NoteClass.B().Flat(),
                NoteClass.A().Sharp() + SimpleInterval.Diminished().Second());
        }

        /// <summary>
        /// Tests subtracting a simple interval from a note class.
        /// </summary>
        [TestMethod]
        public void TestIntervalSubtraction()
        {
            Assert.AreEqual(
                NoteClass.B().Natural(),
                NoteClass.E().Flat() - SimpleInterval.Diminished().Fourth());

            // Subtracting a perfect unison should have no effect
            Assert.AreEqual(
                NoteClass.E().Sharp(),
                NoteClass.E().Sharp() - SimpleInterval.Perfect().Unison());

            Assert.AreEqual(
                NoteClass.A().Flat(),
                NoteClass.F().Sharp() - SimpleInterval.Augmented().Sixth());

            Assert.AreEqual(
                NoteClass.F().Flat(2),
                NoteClass.E().Natural() - SimpleInterval.Augmented(2).Seventh());

            Assert.AreEqual(
                NoteClass.G().Sharp(2),
                NoteClass.F().Flat() - SimpleInterval.Diminished(3).Seventh());
        }
    }
}
