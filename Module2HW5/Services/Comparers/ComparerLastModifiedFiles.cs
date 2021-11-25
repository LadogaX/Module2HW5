using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Services.Comparers
{
    public class ComparerLastModifiedFiles : IComparer<FileInfo>
    {
            public int Compare(FileInfo fileInfo1, FileInfo fileInfo2)
            {
                if (fileInfo1.LastWriteTimeUtc > fileInfo2.LastWriteTimeUtc)
                {
                    return 1;
                }
                else if (fileInfo1.LastWriteTimeUtc < fileInfo2.LastWriteTimeUtc)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
    }
}
