using System;
using System.IO;
using Module2HW5.Services.Abstractions;
using Module2HW5.Services.Comparers;

namespace Module2HW5.Services
{
    public class FileService : IFileService
    {
        private IWriterService _writer;
        private string _logFolderPath;
        public FileService(IWriterService writer, IConfigService config)
        {
            _writer = writer;
            Config = config;
            _logFolderPath = config.Config.LogFolderPath;

            if (!Directory.Exists(_logFolderPath))
            {
                Directory.CreateDirectory(_logFolderPath);
            }

            ClearOldLogFiles();
            OpenWriter();
        }

        public IConfigService Config { get; set; }

        public void OpenWriter()
        {
            OpenWriter(GetNameLogFile());
        }

        public string GetNameLogFile()
        {
            return Path.Combine(Config.Config.LogFolderPath, $"{DateTime.UtcNow.ToString("hh.mm.ss dd.MM.yyyy")}.txt");
        }

        public void OpenWriter(string logFileName)
        {
            _writer.StartWriter(logFileName);
        }

        public void Append(string log)
        {
            _writer.Append(log);
        }

        public void CloseWriter()
        {
            CloseWriter(_writer);
        }

        public void CloseWriter(IWriterService writer)
        {
            writer.CloseWriter();
        }

        public void ClearOldLogFiles()
        {
            var directoryInfo = new DirectoryInfo(_logFolderPath);
            var fileInfos = directoryInfo.GetFiles("*.txt");

            Array.Sort<FileInfo>(fileInfos, new ComparerLastModifiedFiles());

            var countDeleteFles = fileInfos.Length - Config.Config.CountLogFilesInFolder;

            for (var i = 0; i < countDeleteFles; i++)
            {
                try
                {
                    File.Delete(fileInfos[i].FullName);
                }
                catch
                {
                }
            }
        }
    }
}
