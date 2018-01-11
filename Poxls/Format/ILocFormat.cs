using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poxls.Format
{
    interface ILocFormat
    {
        List<string> MetaData { get; }
        List<LocEntry> Entries { get; }

        void Read(string path, IProgress<string> progressHandler);
        void Write(string path, IProgress<string> progressHandler);
    }
}
