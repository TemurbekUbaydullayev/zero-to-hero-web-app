using Microsoft.AspNetCore.Http;

namespace ZeroToHero.Application.Core.Core;

public interface IFileService
{
    public string ResumeFolderName { get; }
    Task<string> SaveFileAsync(IFormFile file);
    Task<bool> DeleteFileAsync(string relativeResumePath);
}