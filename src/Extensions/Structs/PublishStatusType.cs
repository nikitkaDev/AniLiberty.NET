namespace AniLiberty.NET.Domain.Structs
{
    public readonly record struct PublishStatusType(string Value)
    {
        public override string ToString() => Value;

        public static implicit operator string(PublishStatusType type) => type.Value;
        public static implicit operator PublishStatusType(string value) => new(value);

        public static readonly PublishStatusType IsOngoing = new("IS_ONGOING");
        public static readonly PublishStatusType IsNotOngoing = new("IS_NOT_ONGOING");
        public static readonly PublishStatusType None = new("");
    }
}
