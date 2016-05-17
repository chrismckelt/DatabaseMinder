using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMinder
{
    public class CommandArgs
    {
        public bool Help { get; set; }
        public bool Backup { get; set; }
        public string FileName { get; set; }
        public bool Restore { get; set; }
        public bool Download { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ZipFileName { get; set; }
        public string XfromDirectory { get; set; }
        public string ToDirectory { get; set; }
        public string ServerName { get; set; }
        public bool PromptsEnabled { get; set; }
        public string NameOfCredentials { get; set; }

        public string CombinedFilePath => System.IO.Path.Combine(XfromDirectory, FileName);
    }
}
