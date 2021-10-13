using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.Music.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music.Test.Intervals
{
    /// <summary>
    /// Tests for the <see cref="SimpleInterval"/> record.
    /// </summary>
    [TestClass]
    public class SimpleIntervalTest
    {
        /// <summary>
        /// Tests addition of two simple intervals.
        /// </summary>
        [TestMethod]
        public void TestAddition()
        {
            // Adding a unison should have no effect
            Assert.AreEqual(
                SimpleInterval.Major().Second(),
                SimpleInterval.Major().Second() + SimpleInterval.Perfect().Unison());

            Assert.AreEqual(
                SimpleInterval.Major().Third(),
                SimpleInterval.Major().Second() + SimpleInterval.Major().Second());

            Assert.AreEqual(
                SimpleInterval.Minor().Third(),
                SimpleInterval.Major().Sixth() + SimpleInterval.Diminished().Fifth());

            Assert.AreEqual(
                SimpleInterval.Augmented().Fifth(),
                SimpleInterval.Major().Third() + SimpleInterval.Major().Third());

            Assert.AreEqual(
                SimpleInterval.Diminished().Fourth(),
                SimpleInterval.Diminished().Third() + SimpleInterval.Major().Second());
        }

        /// <summary>
        /// Tests subtraction of two simple intervals.
        /// </summary>
        [TestMethod]
        public void TestSubtraction()
        {
            Assert.AreEqual(
                SimpleInterval.Major().Third(),
                SimpleInterval.Perfect().Fourth() - SimpleInterval.Minor().Second());

            Assert.AreEqual(
                SimpleInterval.Perfect().Fifth(),
                SimpleInterval.Major().Seventh() - SimpleInterval.Major().Third());

            Assert.AreEqual(
                SimpleInterval.Major().Second(),
                SimpleInterval.Augmented().Fifth() - SimpleInterval.Augmented().Fourth());

            Assert.AreEqual(
                SimpleInterval.Diminished().Fifth(),
                SimpleInterval.Minor().Second() - SimpleInterval.Perfect().Fifth());
        }

        /// <summary>
        /// Tests inversion of a simple interval.
        /// </summary>
        [TestMethod]
        public void TestInversion()
        {
            Assert.AreEqual(
                SimpleInterval.Diminished().Fifth(),
                SimpleInterval.Augmented().Fourth().Inverted());

            Assert.AreEqual(
                SimpleInterval.Minor().Sixth(),
                SimpleInterval.Major().Third().Inverted());

            // Should be its own inversion
            Assert.AreEqual(
                SimpleInterval.Perfect().Unison(),
                SimpleInterval.Perfect().Unison().Inverted());
        }
    }
}
