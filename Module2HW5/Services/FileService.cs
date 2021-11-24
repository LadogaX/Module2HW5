using System;
using System.IO;
using Module2HW5.Services.Abstractions;
using Module2HW5.Services.Comparers;

namespace Module2HW5.Services
{
    public class FileService : IFileService
    {
        private StreamWriter _streamWriter;
        private string _logFolderPath;
        public FileService(IConfigService config)
        {
            Config = config;
            _logFolderPath = config.Config.LogFolderPath;
            if (!Directory.Exists(_logFolderPath))
            {
                Directory.CreateDirectory(_logFolderPath);
            }

            ClearOldLogFiles();
            OpenStreamWriter();
        }

        public IConfigService Config { get; set; }

        public void OpenStreamWriter()
        {
            var logFileName = Path.Combine(Config.Config.LogFolderPath, $"{DateTime.UtcNow.ToString("hh.mm.ss dd.MM.yyyy")}.txt");
            OpenStreamWriter(logFileName);
        }

        public StreamWriter OpenStreamWriter(string logFileName)
        {
            _streamWriter = new StreamWriter(logFileName);
            return _streamWriter;
        }

        public void Append(string log)
        {
            _streamWriter.WriteLine(log);
        }

        public void CloseStreamWriter()
        {
            CloseStreamWriter(_streamWriter);
        }

        public void CloseStreamWriter(StreamWriter stringWriter)
        {
            stringWriter.Close();
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
