using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music.Test
{
    /// <summary>
    /// Tests for the <see cref="PitchInfo"/> struct.
    /// </summary>
    [TestClass]
    public class PitchInfoTest
    {
        /// <summary>
        /// Tests the <see cref="PitchInfo.Frequency"/> property.
        /// </summary>
        [TestMethod]
        public void TestFrequency()
        {
            // C4
            Assert.AreEqual(261.62556530059863467784999352330470136445386034203983086418048943,
                new PitchInfo(Class: 0, Octave: 4).Frequency);

            // Db4
            Assert.AreEqual(277.18263097687209624878633360121023712545532223433175561803452467,
                new PitchInfo(Class: 1, Octave: 4).Frequency);

            // A4
            Assert.AreEqual(440.0, new PitchInfo(Class: 9, Octave: 4).Frequency);
        }
    }
}
