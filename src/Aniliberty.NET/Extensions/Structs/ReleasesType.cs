namespace AniLiberty.NET.Extensions.Structs
{
    public readonly record struct ReleasesType(string Value)
    {
        public override string ToString() => Value;
        
        public static implicit operator string(ReleasesType type) => type.Value;
        public static implicit operator ReleasesType(string value) => new(value);

        public static readonly ReleasesType TV = new("TV");
        public static readonly ReleasesType ONA = new("ONA");
        public static readonly ReleasesType WEB = new("WEB");
        public static readonly ReleasesType OVA = new("OVA");
        public static readonly ReleasesType OAD = new("OAD");
        public static readonly ReleasesType MOVIE = new("MOVIE");
        public static readonly ReleasesType DORAMA = new("DORAMA");
        public static readonly ReleasesType SPECIAL = new("SPECIAL");
        public static readonly ReleasesType None = new("");
    }
}
