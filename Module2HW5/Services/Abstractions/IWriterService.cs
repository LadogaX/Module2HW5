using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Services.Abstractions
{
    public interface IWriterService
    {
        void StartWriter(string logFileName);

        void Append(string log);
        void CloseWriter();

        void CloseWriter(StreamWriter stringWriter);
    }
}