namespace MisProject.Helpers.Converters;

public static class NameGenerator
{
    public static string GenerateUniqueCode() => Guid.NewGuid().ToString().Replace("-", "");
}