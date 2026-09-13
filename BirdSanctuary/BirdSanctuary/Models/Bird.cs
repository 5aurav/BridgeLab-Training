namespace BirdSanctuary.Models
{
    public abstract class Bird : IEquatable<Bird>
    {
        public enum Gender
        {
            Male,
            Female
        }

        public string Id { get; }
        public string Name { get; }
        public Gender gender { get; }

        protected Bird(string id, string name, Gender gender)
        {
            Id = id;
            Name = name;
            this.gender = gender;
        }

        public abstract void Eat();

        public bool Equals(Bird? other)
        {
            if (other is null)
                return false;

            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Bird);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
