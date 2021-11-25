using System;
using System.IO;
using Module2HW5.Models;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
   public class WriterService : IWriterService
    {
        private StreamWriter _streamWriter;

        public void StartWriter(string logFileName)
        {
            _streamWriter = new StreamWriter(logFileName);
        }

        public void Append(string log)
        {
            _streamWriter.WriteLine(log);
        }

        public void CloseWriter()
        {
            CloseWriter(_streamWriter);
        }

        public void CloseWriter(StreamWriter streamWriter)
        {
            streamWriter.Close();
        }
    }
}
