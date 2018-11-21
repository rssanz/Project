using log4net;
using ServiceUtilsInterface.Interfaces;
using System;
using System.IO;

namespace ServiceUtils.Implementations
{
    public class FileService : IFileService
    {
        private readonly ILog _logger;

        public FileService(ILog logger)
        {
            _logger = logger;
        }

        public string ReadFile(string filePath)
        {
            var text = String.Empty;

            try
            {
                _logger.Info($"FileService.ReadFile {filePath}");
                text = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                    _logger.Error($"FileService.ReadFile FILE NOT FOUND {filePath}: {e}");
                else if (e is DirectoryNotFoundException)
                    _logger.Error($"FileService.ReadFile DIRECTORY NOT FOUND {filePath}: {e}");
                else
                    _logger.Error($"FileService.ReadFile {filePath}: {e}");
            }

            return text;
        }

        public void WriteFile(string filePath, string content)
        {
            try
            {
                _logger.Info("FileService.WriteFile");
                File.WriteAllText(filePath, content);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                    _logger.Error($"FileService.WriteFile FILE NOT FOUND {filePath}: {e}");
                else if (e is DirectoryNotFoundException)
                    _logger.Error($"FileService.WriteFile DIRECTORY NOT FOUND {filePath}: {e}");
                else
                    _logger.Error($"FileService.WriteFile {filePath}: {e}");
            }
        }
    }
}
