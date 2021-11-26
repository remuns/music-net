﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.Music.Chords;
using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music.Test.Chords
{
    /// <summary>
    /// Tests for the <see cref="InversionChordSchema"/> class.
    /// </summary>
    [TestClass]
    public class InversionChordSchemaTest
    {
        /// <summary>
        /// Ensures that the intervals of an inversion chord schema are returned in the correct order.
        /// </summary>
        [TestMethod]
        public void TestIntervals()
        {
            var rootTriad = new InversionChordSchema(TriadSchema.Major, 0);
            Assert.IsTrue(TriadSchema.Major.Intervals.SequenceEqual(rootTriad.Intervals));

            var triad64 = new InversionChordSchema(TriadSchema.Major, 2);
            Assert.IsTrue(
                new SimpleInterval[]
                {
                    SimpleInterval.Perfect().Unison(),
                    SimpleInterval.Perfect().Fourth(),
                    SimpleInterval.Major().Sixth()
                }.SequenceEqual(triad64.Intervals));
        }
    }
}
