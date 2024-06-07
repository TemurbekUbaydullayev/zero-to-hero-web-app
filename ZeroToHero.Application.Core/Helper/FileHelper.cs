namespace ZeroToHero.Application.Core.Helper;

public static class FileHelper
{
    public static string MakeFileName(this string fileName)
        => $"{fileName}-{Guid.NewGuid()}-cv";
}