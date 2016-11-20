using System.IO;

namespace DatabaseMinder
{
    public class CommandArgs
    {
        public bool Help { get; set; }
        public bool Backup { get; set; }
        public bool Restore { get; set; }
        public string DatabaseName { get; set; }
        public bool ZipBackup { get; set; }

        public string Folder { get; set; }
        public string ServerName { get; set; }
        public bool PromptsEnabled { get; set; }
        public string NameOfCredentials { get; set; }
        public string DateTimeFormat { get; set; }

        public string BackFullPath => Path.Combine(Folder, DatabaseName.ToFileName("bak", DateTimeFormat));

    }
}
