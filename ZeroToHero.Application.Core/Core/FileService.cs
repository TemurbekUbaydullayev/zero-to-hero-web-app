using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serilog;
using ZeroToHero.Application.Core.Helper;

namespace ZeroToHero.Application.Core.Core;

public class FileService(IWebHostEnvironment environment) : IFileService
{
    //private readonly IWebHostEnvironment _environment = environment;
    private readonly string _basePath = environment.WebRootPath;
    private const string _fileFolderName = "resumes";

    public string ResumeFolderName => _fileFolderName;

    public Task<bool> DeleteFileAsync(string relativeResumePath)
    {
        throw new NotImplementedException();
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        if (!Directory.Exists(_basePath))
        {
            Log.Error("wwwroot is not exists!");
            Directory.CreateDirectory(_basePath);
        }

        if (!Directory.Exists(Path.Combine(_basePath, _fileFolderName)))
        {
            Log.Error("resumes not exist!");
            Directory.CreateDirectory(Path.Combine(_basePath, _fileFolderName));
        }

        string fileName = file.FileName.MakeFileName();
        string partPath = Path.Combine(_fileFolderName, fileName);
        string path = Path.Combine(_basePath, partPath);

        var stream = File.Create(path);
        await file.CopyToAsync(stream);
        stream.Close();

        return partPath;
    }
}
