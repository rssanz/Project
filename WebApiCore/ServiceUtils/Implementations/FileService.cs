using Microsoft.Extensions.Logging;
using ServiceUtils.Interfaces;
using System;
using System.IO;

namespace ServiceUtils.Implementations
{
    public class FileService : IFileService
    {
        private readonly ILogger<RequestService> _logger;

        public FileService(ILogger<RequestService> logger)
        {
            _logger = logger;
        }

        public string ReadFile(string filePath)
        {
            var text = String.Empty;

            try
            {
                _logger.LogInformation("FileService.ReadFile {path}", filePath);
                text = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                    _logger.LogError("FileService.ReadFile FILE NOT FOUND {path}: {e}", filePath, e);
                else if (e is DirectoryNotFoundException)
                    _logger.LogError("FileService.ReadFile DIRECTORY NOT FOUND {path}: {e}", filePath, e);
                else
                    _logger.LogError("FileService.ReadFile {path}: {e}", filePath, e);
            }

            return text;
        }

        public void WriteFile(string filePath, string content)
        {
            try
            {
                _logger.LogInformation("FileService.WriteFile {path}", filePath);
                File.WriteAllText(filePath, content);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                    _logger.LogError("FileService.WriteFile FILE NOT FOUND {path}: {e}", filePath, e);
                else if (e is DirectoryNotFoundException)
                    _logger.LogError("FileService.WriteFile DIRECTORY NOT FOUND {path}: {e}", filePath, e);
                else
                    _logger.LogError("FileService.WriteFile {path}: {e}", filePath, e);
            }
        }
    }
}
