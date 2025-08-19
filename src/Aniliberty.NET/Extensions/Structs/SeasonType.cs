namespace AniLiberty.NET.Extensions.Structs
{
    public readonly record struct SeasonType(string Value)
    {
        public override string ToString() => Value;

        public static implicit operator string(SeasonType type) => type.Value;
        public static implicit operator SeasonType(string value) => new(value);

        public static readonly SeasonType Winter = new("winter");
        public static readonly SeasonType Spring = new("spring");
        public static readonly SeasonType Summer = new("summer");
        public static readonly SeasonType Autumn = new("autumn");
        public static readonly SeasonType None = new("");
    }
}
