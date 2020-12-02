using System.Text.RegularExpressions;

namespace DDDPractice.Domain
{
    public abstract class ValueObject<T> where T: ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            //making sure the obj coming through is of the same type as the current value object
            //we dnt need to duplicate this check in the derived classes.
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            return EqualsCore(valueObject);
        }

        //implementing classes will implement the equality logic
        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        //implementing classes will implement the hasCode logic
        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }


}