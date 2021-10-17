using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.Music.Intervals
{
    /// <summary>
    /// Represents an interval equipped with a direction.
    /// </summary>
    /// <remarks>
    /// The default value of this struct wraps a perfect unison.
    /// </remarks>
    public readonly struct DirectedInterval : IEquatable<DirectedInterval>
    {
        /// <summary>
        /// The value of the interval being represented.
        /// </summary>
        public Interval Value => _value ?? Interval.PerfectUnison;
        private readonly Interval _value;

        /// <summary>
        /// The sign of the interval being represented.
        /// </summary>
        public int Sign { get; }

        /// <summary>
        /// Constructs a new <see cref="DirectedInterval"/> representing the interval passed in
        /// with a positive direction.
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static DirectedInterval Up(Interval Value) => new(Value, 1);

        /// <summary>
        /// Constructs a new <see cref="DirectedInterval"/> representing the interval passed in
        /// with a negative direction.
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static DirectedInterval Down(Interval Value) => new(Value, -1);

        private DirectedInterval(Interval Value, int Sign)
        {
            if (Value.Base.Number == 1 && Value.Octaves == 0) // Is a unison
            {
                if (Sign < 0)
                {
                    // Invert the value to remove ambiguity
                    Value = Value with { Base = Value.Base.Inverted() };
                }
                Sign = 0; // Unisons have no sign
            }

            this._value = Value;
            this.Sign = Sign;
        }

        /// <summary>
        /// Gets the inverse of the directed interval passed in.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static DirectedInterval operator -(DirectedInterval i)
        {
            if (i.Sign == 0)
            {
                // Invert unisons to yield the negative
                return new(i.Value with { Base = i.Value.Base.Inverted() }, 0);
            }
            else
            {
                return new(i.Value, -i.Sign);
            }
        }

        /// <summary>
        /// Determines if the two <see cref="DirectedInterval"/> instances are equal.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(DirectedInterval lhs, DirectedInterval rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Determines if the two <see cref="DirectedInterval"/> instances are not equal.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(DirectedInterval lhs, DirectedInterval rhs)
            => !lhs.Equals(rhs);

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj) => obj switch
        {
            DirectedInterval di => this.Equals(di),
            _ => false,
        };

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Value, Sign);

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(DirectedInterval other)
        {
            return Value == other.Value && Sign == other.Sign;
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
            => $"{nameof(DirectedInterval)}.{(Sign < 0 ? "Down" : "Up")}({Value})";
    }
}
