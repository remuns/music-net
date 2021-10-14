using Microsoft.VisualStudio.TestTools.UnitTesting;
using REMuns.Music.Intervals;
using REMuns.Music.Scales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music.Test.Scales
{
    /// <summary>
    /// Tests for the <see cref="StandardModeType"/> enum.
    /// </summary>
    [TestClass]
    public class StandardModeTypeTest
    {
        /// <summary>
        /// Tests the intervals returned from the <see cref="StandardModeTypes.Intervals"/> method.
        /// </summary>
        [TestMethod]
        public void TestIntervals()
        {
            // Initialize expected value to expected Lydian result
            var expectedValue = new SimpleInterval[]
            {
                SimpleInterval.Perfect().Unison(),
                SimpleInterval.Major().Second(),
                SimpleInterval.Major().Third(),
                SimpleInterval.Augmented().Fourth(),
                SimpleInterval.Perfect().Fifth(),
                SimpleInterval.Major().Sixth(),
                SimpleInterval.Major().Seventh(),
            };

            // Lydian
            Assert.IsTrue(StandardModeType.Lydian.Intervals().SequenceEqual(expectedValue));

            // Ionian
            expectedValue[3] = SimpleInterval.Perfect().Fourth();
            Assert.IsTrue(StandardModeType.Ionian.Intervals().SequenceEqual(expectedValue));

            // Mixolydian
            expectedValue[6] = SimpleInterval.Minor().Seventh();
            Assert.IsTrue(StandardModeType.Mixolydian.Intervals().SequenceEqual(expectedValue));

            // Dorian
            expectedValue[2] = SimpleInterval.Minor().Third();
            Assert.IsTrue(StandardModeType.Dorian.Intervals().SequenceEqual(expectedValue));

            // Aeolian
            expectedValue[5] = SimpleInterval.Minor().Sixth();
            Assert.IsTrue(StandardModeType.Aeolian.Intervals().SequenceEqual(expectedValue));

            // Phrygian
            expectedValue[1] = SimpleInterval.Minor().Second();
            Assert.IsTrue(StandardModeType.Phrygian.Intervals().SequenceEqual(expectedValue));

            // Locrian
            expectedValue[4] = SimpleInterval.Diminished().Fifth();
            Assert.IsTrue(StandardModeType.Locrian.Intervals().SequenceEqual(expectedValue));
        }
    }
}
