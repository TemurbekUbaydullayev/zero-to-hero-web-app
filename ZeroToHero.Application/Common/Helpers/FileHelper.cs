namespace ZeroToHero.Application.Common.Helpers;

public class FileHelper
{
    public static string MakeFileName(string fileName)
    {
        string guid = Guid.NewGuid().ToString();
        return "file_" + guid + fileName;
    }

    public static string MakeFileUrl(string partPath)
        => "https://you-tube-web-app.herokuapp.com/" + partPath;
}