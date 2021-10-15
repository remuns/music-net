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
    public sealed record StandardMode(StandardModeType Type, NoteClass Root)
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
    }
}
