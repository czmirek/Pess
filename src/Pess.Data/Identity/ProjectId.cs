namespace Pess.Data
{
    using System;

    [Serializable]
    /// <summary>
    /// Value representing the identity of Project.
    /// </summary>
    public readonly struct ProjectId : IComparable<ProjectId>, IComparable<ProjectId?>, IEquatable<ProjectId>, IEquatable<ProjectId?>
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
        static ProjectId()
        {
            Type type = typeof(ProjectId).GetProperty("Value").PropertyType;
            ValueIsNullable = !type.IsValueType || (Nullable.GetUnderlyingType(type) != null);
        }

        /// <summary>
        /// Identity value of the ProjectId.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new value of ProjectId
        /// </summary>
        /// <param name="value">Identity value</param>
        public ProjectId(string value)
        {
            if (ValueIsNullable)
            {
#pragma warning disable CS0472
                if (value == null)
                {
                    throw new InvalidOperationException("The identity " + nameof(ProjectId) + " cannot have a null value. To use null, set the identity property as nullable (\"{nameof(ProjectId)}?\").");
                }
#pragma warning restore CS0472
            }
            Value = value;
        }

        /// <summary>
        /// Creates a new value of <see cref="ProjectId"/>.
        /// </summary>
        /// <param name="localProjectId">Identity value</param>
        /// <returns>Identity struct</returns>
        public static ProjectId New(string localProjectId) => new ProjectId(localProjectId);

        /// <summary>
        /// Checks whether two identity values are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(ProjectId other) => CompareTo(other) == 0;


        /// <summary>
        /// Checks whether two identity values (one of them nullable) are equal.
        /// </summary>
        /// <param name="other">Other identity</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(ProjectId? other) => CompareTo(other) == 0;

        /// <summary>
        /// Checks whether two values of <see cref="ProjectId"/> are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ProjectId)
                return CompareTo((ProjectId)obj) == 0;

            return false;
        }

        /// <summary>
        /// Compares values of two <see cref="ProjectId"/> identities.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>0 if two <see cref="ProjectId"/> are equal, 1 if this <see cref="ProjectId"/> comes after the other <see cref="ProjectId"/> and -1 if this <see cref="ProjectId"/> comes before the other <see cref="ProjectId"/>.</returns>
        public int CompareTo(ProjectId other) => Value.CompareTo(other.Value);

        /// <summary>
        /// Compares the struct with the other nullable struct value.
        /// </summary>
        /// <param name="other">Other nullable struct value</param>
        /// <returns>0 if two <see cref="ProjectId"/> are equal, 1 if this <see cref="ProjectId"/> comes after the other <see cref="ProjectId"/> and -1 if this <see cref="ProjectId"/> comes before the other <see cref="ProjectId"/>.</returns>
        public int CompareTo(ProjectId? other)
        {
            // if nullable has value, compare the struct like a non-nullable
            if (other.HasValue)
                return other.Value.CompareTo(this);

            //otherwise the non-null value is considered greater
            return 1;
        }

        /// <summary>
        /// Returns the hashcode of the <see cref="ProjectId"/>.
        /// </summary>
        /// <returns>Hash code of <see cref="ProjectId"/></returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns the string representation of <see cref="ProjectId"/>.
        /// </summary>
        /// <returns>String representation of <see cref="ProjectId"/></returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        /// Method for allowing explicit conversion from the primitive type to the <see cref="ProjectId"/>.
        /// </summary>
        /// <param name="value">Value of the identity</param>
        public static explicit operator ProjectId(string value) => new ProjectId(value);

        /// <summary>
        /// Method for allowing explicit conversion from <see cref="ProjectId"/> to the identity primitive type.
        /// </summary>
        /// <param name="localProjectId">Identity struct</param>
        public static explicit operator string(ProjectId localProjectId) => localProjectId.Value;

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="ProjectId"/>.
        /// </summary>
        /// <param name="a">First <see cref="ProjectId"/></param>
        /// <param name="b">Second <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(ProjectId a, ProjectId b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="ProjectId"/>.
        /// </summary>
        /// <param name="a">First <see cref="ProjectId"/></param>
        /// <param name="b">Second <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(ProjectId a, ProjectId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="ProjectId"/> with one
        /// Project being nullable. <see cref="ProjectId"/>? null value is considered equal 
        /// with <see cref="ProjectId"/>.Value == null. Therefore if the underlying type is nullable and the
        /// value contains null, that is considered the same thing as if the struct itself was null.
        /// </summary>
        /// <param name="a">First <see cref="ProjectId"/></param>
        /// <param name="b">Second <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(ProjectId? a, ProjectId b) => b.CompareTo(a) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="ProjectId"/> with one
        /// <see cref="ProjectId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="ProjectId"/></param>
        /// <param name="b">Second <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(ProjectId? a, ProjectId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="ProjectId"/> with one
        /// <see cref="ProjectId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="ProjectId"/></param>
        /// <param name="b">Second <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are equal. False otherwise.</returns>
        public static bool operator ==(ProjectId a, ProjectId? b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="ProjectId"/> with one
        /// <see cref="ProjectId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="ProjectId"/></param>
        /// <param name="b">Second <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(ProjectId a, ProjectId? b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two <see cref="ProjectId"/> with one
        /// <see cref="ProjectId"/> being nullable.
        /// </summary>
        /// <param name="a">First ProjectId</param>
        /// <param name="b">Second ProjectId</param>
        /// <returns>True if two ProjectId values are equal. False otherwise.</returns>
        public static bool operator ==(ProjectId? a, ProjectId? b) => CompareNullableWithNullable(a, b);

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two <see cref="ProjectId"/> with one
        /// <see cref="ProjectId"/> being nullable.
        /// </summary>
        /// <param name="a">First <see cref="ProjectId"/></param>
        /// <param name="b">Second <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are not equal. False otherwise.</returns>
        public static bool operator !=(ProjectId? a, ProjectId? b) => !CompareNullableWithNullable(a, b);

        /// <summary>
        /// Private helper method for comparing two nullable <see cref="ProjectId"/> values.
        /// </summary>
        /// <param name="a">First nullable value of <see cref="ProjectId"/></param>
        /// <param name="b">Second nullable value of <see cref="ProjectId"/></param>
        /// <returns>True if two <see cref="ProjectId"/> values are not equal. False otherwise.</returns>
        private static bool CompareNullableWithNullable(ProjectId? a, ProjectId? b)
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
