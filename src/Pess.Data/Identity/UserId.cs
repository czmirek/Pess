namespace Pess.Data
{

    using System;

    [Serializable]
    /// <summary>
    /// Value representing the identity of User.
    /// </summary>
    public readonly struct UserId : IComparable<UserId>, IComparable<UserId?>, IEquatable<UserId>, IEquatable<UserId?>
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
        static UserId()
        {
            Type type = typeof(UserId).GetProperty("Value").PropertyType;
            ValueIsNullable = !type.IsValueType || (Nullable.GetUnderlyingType(type) != null);
        }

        /// <summary>
        /// Identity value of the UserId.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new value of UserId
        /// </summary>
        /// <param name="value">Identity value</param>
        public UserId(string value)
        {
            if (ValueIsNullable)
            {
#pragma warning disable CS0472
                if (value == null)
                {
                    throw new InvalidOperationException("The identity " + nameof(UserId) + " cannot have a null value. To use null, set the identity property as nullable (\"{nameof(UserId)}?\").");
                }
#pragma warning restore CS0472
            }
            Value = value;
        }

        /// <summary>
        /// Creates a new value of <see cref="UserId"/>.
        /// </summary>
        /// <param name="localUserId">Identity value</param>
        /// <returns>Identity struct</returns>
        public static UserId New(string localUserId) => new UserId(localUserId);

        /// <summary>
        /// Checks whether two identity values are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(UserId other) => CompareTo(other) == 0;


        /// <summary>
        /// Checks whether two identity values (one of them nullable) are equal.
        /// </summary>
        /// <param name="other">Other identity</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(UserId? other) => CompareTo(other) == 0;

        /// <summary>
        /// Checks whether two values of <see cref="UserId"/> are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UserId)
                return CompareTo((UserId)obj) == 0;

            return false;
        }

        /// <summary>
        /// Compares values of two <see cref="UserId"/> identities.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>0 if two <see cref="UserId"/> are equal, 1 if this <see cref="UserId"/> comes after the other <see cref="UserId"/> and -1 if this <see cref="UserId"/> comes before the other <see cref="UserId"/>.</returns>
        public int CompareTo(UserId other) => Value.CompareTo(other.Value);

        /// <summary>
        /// Compares the struct with the other nullable struct value.
        /// </summary>
        /// <param name="other">Other nullable struct value</param>
        /// <returns>0 if two <see cref="UserId"/> are equal, 1 if this <see cref="UserId"/> comes after the other <see cref="UserId"/> and -1 if this <see cref="UserId"/> comes before the other <see cref="UserId"/>.</returns>
        public int CompareTo(UserId? other)
        {
            // if nullable has value, compare the struct like a non-nullable
            if (other.HasValue)
                return other.Value.CompareTo(this);

            //otherwise the non-null value is considered greater
            return 1;
        }

        /// <summary>
        /// Returns the hashcode of the <see cref="UserId"/>.
        /// </summary>
        /// <returns>Hash code of <see cref="UserId"/></returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns the string representation of <see cref="UserId"/>.
        /// </summary>
        /// <returns>String representation of <see cref="UserId"/></returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        /// Method for allowing explicit conversion from the primitive type to the <see cref="UserId"/>.
        /// </summary>
        /// <param name="value">Value of the identity</param>
        public static explicit operator UserId(string value) => new UserId(value);

        /// <summary>
        /// Method for allowing explicit conversion from <see cref="UserId"/> to the identity primitive type.
        /// </summary>
        /// <param name="localUserId">Identity struct</param>
        public static explicit operator string(UserId localUserId) => localUserId.Value;

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="UserId"/>.
        /// </summary>
        /// <param name="a">First <see cref="UserId"/></param>
        /// <param name="b">Second <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(UserId a, UserId b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="UserId"/>.
        /// </summary>
        /// <param name="a">First <see cref="UserId"/></param>
        /// <param name="b">Second <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(UserId a, UserId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="UserId"/> with one
        /// User being nullable. <see cref="UserId"/>? null value is considered equal 
        /// with <see cref="UserId"/>.Value == null. Therefore if the underlying type is nullable and the
        /// value contains null, that is considered the same thing as if the struct itself was null.
        /// </summary>
        /// <param name="a">First <see cref="UserId"/></param>
        /// <param name="b">Second <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(UserId? a, UserId b) => b.CompareTo(a) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="UserId"/> with one
        /// <see cref="UserId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="UserId"/></param>
        /// <param name="b">Second <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(UserId? a, UserId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="UserId"/> with one
        /// <see cref="UserId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="UserId"/></param>
        /// <param name="b">Second <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(UserId a, UserId? b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="UserId"/> with one
        /// <see cref="UserId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="UserId"/></param>
        /// <param name="b">Second <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(UserId a, UserId? b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="UserId"/> with one
        /// <see cref="UserId"/> being nullable.
        /// </summary>
        /// <param name="a">First UserId</param>
        /// <param name="b">Second UserId</param>
        /// <returns>True if two UserId values are equal. False otherwise.</returns>
        public static bool operator ==(UserId? a, UserId? b) => CompareNullableWithNullable(a, b);

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="UserId"/> with one
        /// <see cref="UserId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="UserId"/></param>
        /// <param name="b">Second <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(UserId? a, UserId? b) => !CompareNullableWithNullable(a, b);

        /// <summary>
        /// Private helper method for comparing two nullable <see cref="UserId"/> values.
        /// </summary>
        /// <param name="a">First nullable value of <see cref="UserId"/></param>
        /// <param name="b">Second nullable value of <see cref="UserId"/></param>
        /// <returns>True if two <see cref="UserId"/> values are not equal. False otherwise.</returns>
        private static bool CompareNullableWithNullable(UserId? a, UserId? b)
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