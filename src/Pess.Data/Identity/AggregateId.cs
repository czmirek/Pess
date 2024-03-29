﻿namespace Pess.Data
{
    using System;

    [Serializable]
    /// <summary>
    /// Value representing the identity of Aggregate.
    /// </summary>
    public readonly struct AggregateId : IComparable<AggregateId>, IComparable<AggregateId?>, IEquatable<AggregateId>, IEquatable<AggregateId?>
    {
        /// <summary>
        /// Determines whether the type of the Value property is nullable or not.
        /// This information is required in operator overloading methods where 
        /// values of nullable and/or non-nullable structs are compared.
        /// </summary>
        private static readonly bool ValueIsNullable = false;

        /// <summary>
        /// Initializes the <see cref="ValueIsNullable"/> static field.
        /// </summary>
        static AggregateId()
        {
            Type type = typeof(AggregateId).GetProperty("Value").PropertyType;
            ValueIsNullable = !type.IsValueType || (Nullable.GetUnderlyingType(type) != null);
        }

        /// <summary>
        /// Identity value of the AggregateId.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new value of AggregateId
        /// </summary>
        /// <param name="value">Identity value</param>
        public AggregateId(string value)
        {
            if (ValueIsNullable)
            {
#pragma warning disable CS0472
                if (value == null)
                {
                    throw new InvalidOperationException("The identity " + nameof(AggregateId) + " cannot have a null value. To use null, set the identity property as nullable (\"{nameof(AggregateId)}?\").");
                }
#pragma warning restore CS0472
            }
            Value = value;
        }

        /// <summary>
        /// Creates a new value of <see cref="AggregateId"/>.
        /// </summary>
        /// <param name="localAggregateId">Identity value</param>
        /// <returns>Identity struct</returns>
        public static AggregateId New(string localAggregateId) => new AggregateId(localAggregateId);

        /// <summary>
        /// Checks whether two identity values are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(AggregateId other) => CompareTo(other) == 0;


        /// <summary>
        /// Checks whether two identity values (one of them nullable) are equal.
        /// </summary>
        /// <param name="other">Other identity</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(AggregateId? other) => CompareTo(other) == 0;

        /// <summary>
        /// Checks whether two values of <see cref="AggregateId"/> are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AggregateId)
                return CompareTo((AggregateId)obj) == 0;

            return false;
        }

        /// <summary>
        /// Compares values of two <see cref="AggregateId"/> identities.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>0 if two <see cref="AggregateId"/> are equal, 1 if this <see cref="AggregateId"/> comes after the other <see cref="AggregateId"/> and -1 if this <see cref="AggregateId"/> comes before the other <see cref="AggregateId"/>.</returns>
        public int CompareTo(AggregateId other) => Value.CompareTo(other.Value);

        /// <summary>
        /// Compares the struct with the other nullable struct value.
        /// </summary>
        /// <param name="other">Other nullable struct value</param>
        /// <returns>0 if two <see cref="AggregateId"/> are equal, 1 if this <see cref="AggregateId"/> comes after the other <see cref="AggregateId"/> and -1 if this <see cref="AggregateId"/> comes before the other <see cref="AggregateId"/>.</returns>
        public int CompareTo(AggregateId? other)
        {
            // if nullable has value, compare the struct like a non-nullable
            if (other.HasValue)
                return other.Value.CompareTo(this);

            //otherwise the non-null value is considered greater
            return 1;
        }

        /// <summary>
        /// Returns the hashcode of the <see cref="AggregateId"/>.
        /// </summary>
        /// <returns>Hash code of <see cref="AggregateId"/></returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns the string representation of <see cref="AggregateId"/>.
        /// </summary>
        /// <returns>String representation of <see cref="AggregateId"/></returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        /// Method for allowing explicit conversion from the primitive type to the <see cref="AggregateId"/>.
        /// </summary>
        /// <param name="value">Value of the identity</param>
        public static explicit operator AggregateId(string value) => new AggregateId(value);

        /// <summary>
        /// Method for allowing explicit conversion from <see cref="AggregateId"/> to the identity primitive type.
        /// </summary>
        /// <param name="localAggregateId">Identity struct</param>
        public static explicit operator string(AggregateId localAggregateId) => localAggregateId.Value;

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="AggregateId"/>.
        /// </summary>
        /// <param name="a">First <see cref="AggregateId"/></param>
        /// <param name="b">Second <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(AggregateId a, AggregateId b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="AggregateId"/>.
        /// </summary>
        /// <param name="a">First <see cref="AggregateId"/></param>
        /// <param name="b">Second <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(AggregateId a, AggregateId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="AggregateId"/> with one
        /// Aggregate being nullable. <see cref="AggregateId"/>? null value is considered equal 
        /// with <see cref="AggregateId"/>.Value == null. Therefore if the underlying type is nullable and the
        /// value contains null, that is considered the same thing as if the struct itself was null.
        /// </summary>
        /// <param name="a">First <see cref="AggregateId"/></param>
        /// <param name="b">Second <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(AggregateId? a, AggregateId b) => b.CompareTo(a) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="AggregateId"/> with one
        /// <see cref="AggregateId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="AggregateId"/></param>
        /// <param name="b">Second <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(AggregateId? a, AggregateId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="AggregateId"/> with one
        /// <see cref="AggregateId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="AggregateId"/></param>
        /// <param name="b">Second <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(AggregateId a, AggregateId? b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="AggregateId"/> with one
        /// <see cref="AggregateId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="AggregateId"/></param>
        /// <param name="b">Second <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(AggregateId a, AggregateId? b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="AggregateId"/> with one
        /// <see cref="AggregateId"/> being nullable.
        /// </summary>
        /// <param name="a">First AggregateId</param>
        /// <param name="b">Second AggregateId</param>
        /// <returns>True if two AggregateId values are equal. False otherwise.</returns>
        public static bool operator ==(AggregateId? a, AggregateId? b) => CompareNullableWithNullable(a, b);

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="AggregateId"/> with one
        /// <see cref="AggregateId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="AggregateId"/></param>
        /// <param name="b">Second <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(AggregateId? a, AggregateId? b) => !CompareNullableWithNullable(a, b);

        /// <summary>
        /// Private helper method for comparing two nullable <see cref="AggregateId"/> values.
        /// </summary>
        /// <param name="a">First nullable value of <see cref="AggregateId"/></param>
        /// <param name="b">Second nullable value of <see cref="AggregateId"/></param>
        /// <returns>True if two <see cref="AggregateId"/> values are not equal. False otherwise.</returns>
        private static bool CompareNullableWithNullable(AggregateId? a, AggregateId? b)
        {
            // if neither has value, they are both null and therefore are equal.
            if (!a.HasValue && !b.HasValue)
                return true;

            if (a.HasValue)
                return a.Value == b;

            return b.Value == a;
        }
    }

}