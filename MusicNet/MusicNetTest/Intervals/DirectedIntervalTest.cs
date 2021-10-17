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
    /// Tests for the <see cref="DirectedInterval"/> struct.
    /// </summary>
    [TestClass]
    public class DirectedIntervalTest
    {
        /// <summary>
        /// Tests that construction occurs properly when a unison is passed in as the value.
        /// </summary>
        [TestMethod]
        public void TestUnisonConstruction()
        {
            var augUnison = SimpleInterval.Augmented().Unison();
            var upDirectedInterval = DirectedInterval.Up(augUnison);
            var downDirectedInterval = DirectedInterval.Down(augUnison);

            // The signs of directed intervals wrapping unisons should always be 0
            Assert.AreEqual(0, upDirectedInterval.Sign);
            Assert.AreEqual(0, downDirectedInterval.Sign);

            // Test that up unison wraps the same interval
            Assert.AreEqual(new Interval(augUnison), upDirectedInterval.Value);

            // Test that down unison wraps the inverted interval
            Assert.AreEqual(
                new Interval(SimpleInterval.Diminished().Unison()), downDirectedInterval.Value);
        }
    }
}
