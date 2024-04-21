namespace Infrastructure.Extension
{
    using Optional;

    public static class OptionExtension
    {
        public static Option<T, string> ToOption<T>(this T value)
        {
            return Option.Some<T, string>(value);
        }

        public static Option<T, string> ToNoneOption<T>(this string value)
        {
            return Option.None<T, string>(value);
        }
    }
}
