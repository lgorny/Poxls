﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poxls.Format
{
    interface ILocFormat
    {
        int LocFormatID { get; }
        List<string> MetaData { get; }
        List<LocEntry> Entries { get; }

        Task Read(string path, IProgress<string> progressHandler);
        void Write(string path, IProgress<string> progressHandler);
    }
}
