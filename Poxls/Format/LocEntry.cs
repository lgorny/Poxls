using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poxls.Format
{
    class LocEntry
    {
        public string msgctxt;
        public string msgid;
        public string msgstr;

        public List<string> comments;
        public List<string> translatorComments;
        public List<string> flags;
        public List<string> references;

        public LocEntry()
        {
            comments = new List<string>();
            translatorComments = new List<string>();
            flags = new List<string>();
            references = new List<string>();
        }

        public override string ToString()
        {
            return string.Format("Entry: msgctxt: {0}\n msgid: {1}\n msgstr: {2}\n", msgctxt, msgid, msgstr);
        }
    }
}
