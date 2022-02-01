namespace MisProject.Helpers.Converters;

public static class TextConverters
{
    public static string ToFixedText(this string text) => text.Trim().ToUpper();
}