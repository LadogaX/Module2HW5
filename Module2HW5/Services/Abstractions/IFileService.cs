using System.IO;

namespace Module2HW5.Services.Abstractions
{
    public interface IFileService
    {
        void Append(string log);

        void CloseWriter();

        void CloseWriter(IWriterService writer);
    }
}
