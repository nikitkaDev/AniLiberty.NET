namespace AniLiberty.NET.Extensions.Structs
{
    public readonly record struct ProductionStatusType(string Value)
    {
        public override string ToString() => Value;

        public static implicit operator string(ProductionStatusType type) => type.Value;
        public static implicit operator ProductionStatusType(string value) => new(value);

        public static readonly ProductionStatusType IsInProduction = new("IS_IN_PRODUCTION");
        public static readonly ProductionStatusType IsInNotProduction = new("IS_NOT_IN_PRODUCTION");
        public static readonly ProductionStatusType None = new("");
    }
}