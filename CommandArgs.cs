using System;

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
        public bool ZipBackup { get; set; }
        public string XfromDirectory { get; set; }
        public string Folder { get; set; }
        public string ServerName { get; set; }
        public bool PromptsEnabled { get; set; }
        public string NameOfCredentials { get; set; }

        public string BackFullPath => System.IO.Path.Combine(Folder, ($"{DatabaseName}_{DateTime.Now.ToString("yyyyMMdd")}.bak"));

    }
}
