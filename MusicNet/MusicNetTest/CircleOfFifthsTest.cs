﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music.Test
{
    /// <summary>
    /// Tests for the <see cref="CircleOfFifths"/> class.
    /// </summary>
    [TestClass]
    public class CircleOfFifthsTest
    {
        /// <summary>
        /// Tests comparisons between simple intervals.
        /// </summary>
        [TestMethod]
        public void TestSimpleIntervalComparison()
        {
            // Intervals should compare as equal to themselves
            Assert.AreEqual(0, CircleOfFifths.CompareSimpleIntervals(
                SimpleInterval.Major().Second(),
                SimpleInterval.Major().Second()));

            Assert.AreEqual(-1, CircleOfFifths.CompareSimpleIntervals(
                SimpleInterval.Minor().Second(),
                SimpleInterval.Perfect().Unison()));

            Assert.AreEqual(1, CircleOfFifths.CompareSimpleIntervals(
                SimpleInterval.Augmented().Fourth(),
                SimpleInterval.Major().Seventh()));

            // Are enharmonically equal
            Assert.AreEqual(1, CircleOfFifths.CompareSimpleIntervals(
                SimpleInterval.Augmented().Fourth(),
                SimpleInterval.Diminished().Fifth()));

            Assert.AreEqual(-1, CircleOfFifths.CompareSimpleIntervals(
                SimpleInterval.Major().Second(),
                SimpleInterval.Major().Third()));

            Assert.AreEqual(-1, CircleOfFifths.CompareSimpleIntervals(
                SimpleInterval.Minor().Seventh(),
                SimpleInterval.Perfect().Fourth()));

            Assert.AreEqual(1, CircleOfFifths.CompareSimpleIntervals(
                SimpleInterval.Major().Sixth(),
                SimpleInterval.Perfect().Fifth()));
        }
    }
}
