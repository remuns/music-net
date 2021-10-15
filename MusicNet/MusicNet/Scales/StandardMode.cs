using REMuns.Music.Internal;
using REMuns.Music.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REMuns.Music.Scales
{
    /// <summary>
    /// Represents a standard mode based on a given note class root.
    /// </summary>
    public sealed record StandardMode(NoteClass Root, StandardModeType Type)
    {
        /// <summary>
        /// The type of mode this object represents.
        /// </summary>
        public StandardModeType Type
        {
            get => _type;
            init => _type = EnumChecks.EnsurePropNamed(value, nameof(Type));
        }
        private readonly StandardModeType _type = EnumChecks.EnsureArgNamed(Type, nameof(Type));

        /// <summary>
        /// Gets a collection of the notes this mode is comprised of.
        /// </summary>
        public IEnumerable<NoteClass> Notes => Type.Intervals().Select(i => Root + i);

        /// <summary>
        /// Determines if this mode is enharmonically equivalent to another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsEnharmonicallyEquivalent(StandardMode other)
            => CircleOfFifths.CompareStandardModes(this, other) == 0;
    }
}
