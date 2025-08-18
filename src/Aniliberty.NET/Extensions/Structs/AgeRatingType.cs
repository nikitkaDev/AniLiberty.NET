namespace AniLiberty.NET.Extensions.Structs
{
    public readonly record struct AgeRatingType(string Value)
    {
        public override string ToString() => Value;

        public static implicit operator string(AgeRatingType type) => type.Value;
        public static implicit operator AgeRatingType(string value) => new(value);

        public static readonly AgeRatingType R0Plus = new("R0_PLUS");
        public static readonly AgeRatingType R6Plus = new("R6_PLUS");
        public static readonly AgeRatingType R12Plus = new("R12_PLUS");
        public static readonly AgeRatingType R16Plus = new("R16_PLUS");
        public static readonly AgeRatingType R18Plus = new("R18_PLUS");
        public static readonly AgeRatingType None = new("");
    }
}