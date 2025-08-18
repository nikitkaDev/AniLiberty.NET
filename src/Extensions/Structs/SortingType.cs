namespace AniLiberty.NET.Domain.Structs
{
    public readonly record struct SortingType(string Value)
    {
        public override string ToString() => Value;

        public static implicit operator string(SortingType type) => type.Value;
        public static implicit operator SortingType(string value) => new(value);

        public static readonly SortingType FreshAtDesc = new("FRESH_AT_DESC");
        public static readonly SortingType FreshAtAsc = new("FRESH_AT_ASC");
        public static readonly SortingType RatingDesc = new("RATING_DESC");
        public static readonly SortingType RatingAsc = new("RATING_ASC");
        public static readonly SortingType YearDesc = new("YEAR_DESC");
        public static readonly SortingType YearAsc = new("YEAR_ASC");
        public static readonly SortingType None = new("");
    }
}
