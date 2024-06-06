using Microsoft.AspNetCore.Http;
using Serilog;
using ZeroToHero.Application.Common.Helpers;
using ZeroToHero.Application.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace ZeroToHero.Application.Services;

public class FileService : IFileService
{
    private readonly string _basePath = "..\\..\\..\\ZeroToHero.Application\\wwwroot";
    private const string _resumeFolderName = "resumes";

    public string ResumeFolderName => _resumeFolderName;

    public Task<bool> DeleteFileAsync(string relativeResumePath)
    {
        throw new NotImplementedException();
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        if (!Directory.Exists(_basePath))
        {
            Log.Error("wwwroot is not e xist!");
            Directory.CreateDirectory(_basePath);
        }

        if (!Directory.Exists(Path.Combine(_basePath, _resumeFolderName)))
        {
            Log.Error("resumes not exist!");
            Directory.CreateDirectory(Path.Combine(_basePath, _resumeFolderName));
        }

        string fileName = FileHelper.MakeFileName(file.FileName);
        string partPath = Path.Combine(_resumeFolderName, fileName);
        string path = Path.Combine(_basePath, partPath);

        var stream = File.Create(path);
        await file.CopyToAsync(stream);
        stream.Close();

        return partPath;
    }
}