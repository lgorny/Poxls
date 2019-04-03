using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poxls.Format
{
    class POFormat : ILocFormat
    {
        public int LocFormatID
        {
            get { return 0; }
        }

        private List<string> metaData;
        public List<string> MetaData
        {
            get
            {
                return metaData;
            }
            private set
            {
                metaData = value;
            }
        }

        private List<LocEntry> entries;
        public List<LocEntry> Entries
        {
            get
            {
                return entries;
            }
            private set
            {
                entries = value;
            }
        }

        public POFormat()
        {
            Entries = new List<LocEntry>();
        }

        public POFormat(List<LocEntry> entries, List<string> metaData)
        {
            Entries = entries;
            MetaData = metaData;
        }

        public async Task Read(string path, IProgress<string> progressHandler)
        {
            progressHandler.Report("Starting reading *.PO file...");
            progressHandler.Report("Path: " + path);

            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    // Meta data reading

                    MetaData = new List<string>();

                    while (!stream.EndOfStream)
                    {
                        string line = await stream.ReadLineAsync();

                        if (line == string.Empty)
                            break;

                        MetaData.Add(line);
                    }

                    Entries = new List<LocEntry>();
                    Entries.Add(new LocEntry());

                    // Entries reading
                    while (!stream.EndOfStream)
                    {
                        string line = await stream.ReadLineAsync();

                        if (line == string.Empty)
                        {
                            if(!stream.EndOfStream)
                                Entries.Add(new LocEntry());

                            continue;
                        }

                        await Task.Run(() =>
                        {
                            LocEntry currentEntry = Entries[Entries.Count - 1];

                            string prefix = line.Substring(0, 3);

                            switch (prefix)
                            {
                                case "#. ":
                                    currentEntry.comments.Add(line.Substring(3));
                                    break;
                                case "#  ":
                                    currentEntry.translatorComments.Add(line.Substring(3));
                                    break;
                                case "#, ":
                                    currentEntry.flags = currentEntry.flags.Concat(line.Substring(3).Split(',')).ToList();
                                    break;
                                case "#: ":
                                    currentEntry.references = currentEntry.references.Concat(line.Substring(3).Split(',')).ToList();
                                    break;
                                case "msg":

                                    if (line.IndexOf("msgctxt") == 0)
                                        currentEntry.msgctxt = GetMsgValue(line);
                                    else if (line.IndexOf("msgid") == 0)
                                        currentEntry.msgid = GetMsgValue(line);
                                    else if (line.IndexOf("msgstr") == 0)
                                        currentEntry.msgstr = GetMsgValue(line);

                                    break;
                            }
                        });
                        
                    }

                    progressHandler.Report("Number of entries: " + Entries.Count);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
       
        public void Write(string path, IProgress<string> progressHandler)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                // Meta data
                foreach (var meta in MetaData)
                {
                    writer.WriteLine(meta);
                }
                    
                writer.WriteLine();

                // Entries
                foreach (var entry in Entries)
                {
                    // Comments
                    foreach (var comment in entry.comments)
                    {
                        writer.WriteLine("#. " + comment);
                    }

                    // Translator comments
                    foreach (var comment in entry.translatorComments)
                    {
                        if(!string.IsNullOrWhiteSpace(comment))
                            writer.WriteLine("#  " + comment);
                    }

                    // Flags
                    if (entry.flags.Count > 0)
                    {
                        var line = "#, ";
                        foreach (var flag in entry.flags)
                        {
                            if (!string.IsNullOrWhiteSpace(flag))
                                line += flag + ",";
                        }

                        if (!string.IsNullOrWhiteSpace(line.Substring(0, 3)))
                            writer.WriteLine(line.TrimEnd(','));
                    }

                    // References
                    if (entry.references.Count > 0)
                    {
                        var line = "#: ";
                        foreach (var reference in entry.references)
                        {
                            line += reference + ",";
                        }

                        if (!string.IsNullOrWhiteSpace(line.TrimEnd(',').Substring(0, 3)))
                            writer.WriteLine(line.TrimEnd(','));
                    }

                    writer.WriteLine(GetMsgLine("msgctxt", entry.msgctxt));
                    writer.WriteLine(GetMsgLine("msgid", entry.msgid));
                    writer.WriteLine(GetMsgLine("msgstr", entry.msgstr));
                    writer.WriteLine();
                }
            }
        }

        private string GetMsgValue(string msg)
        {
            return msg.Substring(msg.IndexOf(' ') + 1).TrimStart('"').TrimEnd('"');
        }

        private string GetMsgLine(string msg, string value)
        {
            return msg + " " + '"' + value + '"';
        }
    }
}
