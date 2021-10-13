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
    /// Tests for the <see cref="Interval"/> record.
    /// </summary>
    [TestClass]
    public class IntervalTest
    {
        [TestMethod]
        public void TestWithOctavesAdded()
        {
            var i = new Interval(SimpleInterval.Perfect().Fourth(), 2);
            Assert.AreEqual(
                new Interval(SimpleInterval.Perfect().Fourth(), 3),
                i.WithOctavesAdded(1));
            Assert.AreEqual(
                new Interval(SimpleInterval.Perfect().Fourth(), 1),
                i.WithOctavesAdded(-1));

            // Should fail because octave count would be negative
            Assert.ThrowsException<InvalidOperationException>(() => i.WithOctavesAdded(-3));
        }
    }
}
