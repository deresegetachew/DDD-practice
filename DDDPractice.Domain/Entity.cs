namespace DDDPractice.Domain
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        public override bool Equals(object? obj)
        {
            var entityObj = obj as Entity;
            
            if (ReferenceEquals(entityObj, null))
                return false;
            if (ReferenceEquals(this, entityObj))
                return true;
            if (GetType() != entityObj.GetType())
                return false;
            if (Id == 0 || entityObj.Id == 0)
                return false;

            return Id == entityObj.Id;
        }

        public static bool operator ==(Entity e1, Entity e2)
        {
            if (ReferenceEquals(e1, null) && ReferenceEquals(e2, null))
                return true;
            if (ReferenceEquals(e1, null) || ReferenceEquals(e2, null))
                return false;
            return e1.Equals(e2);
        }

        public static bool operator !=(Entity e1, Entity e2)
        {
            return !(e1 == e2);
        }

        //the objects type and its Id will generate the hash code
        //refer: https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}