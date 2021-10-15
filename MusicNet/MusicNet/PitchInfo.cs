using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMuns.Music
{
    /// <summary>
    /// Describes information about a specific musical pitch.
    /// </summary>
    public readonly struct PitchInfo
    {
        /// <summary>
        /// Gets the class of the pitch being described.
        /// </summary>
        /// <remarks>
        /// This is 'C'-based, so pitch class 0 corresponds to a 'C' note.
        /// </remarks>
        public int Class { get; }

        /// <summary>
        /// Gets the octave of the pitch being described.
        /// </summary>
        public int Octave { get; }

        /// <summary>
        /// Gets the MIDI number of the pitch being described.
        /// </summary>
        /// <remarks>
        /// Note that this may describe pitches outside of the MIDI range, which only supports
        /// 128 distinct values.
        /// </remarks>
        public int MidiNumber => 12 + Octave * 12 + Class;

        /// <summary>
        /// Gets the frequency (in Hertz) of the pitch being described. 
        /// </summary>
        public double Frequency
        {
            get
            {
                // Use a table to get the factor to multiply a power of 2 by to avoid
                // rounding errors
#pragma warning disable CS8509 // Already know the value is one of the following
                var classFactor = Class switch
#pragma warning restore CS8509
                {
                    0 => 16.351597831287414667365624595206543835278366271377489429011280589,
                    1 => 17.323914436054506015549145850075639820340957639645734726127157792,
                    2 => 18.354047994837972516423938366286225655045365423596476582910848667,
                    3 => 19.445436482630056921023219957883348580332988286433036006179346397,
                    4 => 20.601722307054370608490110065409692199154583863811519551064077856,
                    5 => 21.826764464562742777835952539994238580383033258622978884863929225,
                    6 => 23.124651419477149933355950596413409613600942214811574047363717364,
                    7 => 24.499714748859330880356220653739093969648346936649411093053317286,
                    8 => 25.956543598746571157652611808357195340208128341815427377908441413,
                    9 => 27.5,
                    10 => 29.135235094880619775450195611024396771428118731090104785378231865,
                    11 => 30.867706328507756989422158866177436696391305541884635719611262511,
                };

                return Math.Pow(2, Octave) * classFactor;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="PitchInfo"/> struct.
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Octave"></param>
        public PitchInfo(int Class, int Octave)
        {
            if (Class < 0 || Class >= 12)
            {
                throw new ArgumentException(
                    $"{nameof(Class)} must be in the range 0..11, inclusive");
            }
            this.Class = Class;
            this.Octave = Octave;
        }
    }
}
