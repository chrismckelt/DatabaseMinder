using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMinder
{
    public static class Message
    {
        public static void ShowHeader()
        {
            var sb = new StringBuilder();
            sb.AppendLine("This utility performs actions such as.");
            sb.AppendLine("- database backup");
            sb.AppendLine("- database restore");
            sb.AppendLine("- zip .bak files");
            Consoler.ShowHeader("DatabaseName Minder", sb.ToString());
        }

        public static void ShowHelpAndExit(bool noPrompt = false)
        {
            Consoler.Title("Usage:");
            Consoler.Write("/help\t\t\tShow help");
            Consoler.Write("");
            Consoler.Write("Example:");
            Consoler.Write("");
            Consoler.Write(@"DatabaseMinder.Runner.exe /e /p /b /z /d DatabaseMinder /f c:\temp");
            Consoler.Write("");
            Consoler.Write("Arguments:");
            Consoler.Write("");
            Consoler.Write("\t/e EnableArgsModeViaConfig - true or false --> use config args or command line args");
            Consoler.Write("\t/p PromptsEnabled - true or false -->  pause and show prompts on the console (or skip)");
            Consoler.Write("\t/r Restore - true or false --> Restore database");
            Consoler.Write("\t/b Backup - true or false --> Backup database");
            Consoler.Write("\t/d DatabaseName - the database name to back or restore");
            Consoler.Write("\t/s ServerName - leave blank for localhost");
            Consoler.Write("\t/f Folder - folder to use for backup,restore,zip");
            //Consoler.Write("\t/c ConnectionString - for backups / restore");
            Consoler.Write("\t/z ZipBackup -  true or false --> after backup zip the .bak file");
            ShowPauseAndExit(noPrompt);
        }

        public static void ShowCompletedAndExit(bool noPrompt = true)
        {
            Consoler.Success(noPrompt);
            if (noPrompt) Environment.Exit(0);
        }

        public static void ShowErrorAndExit(Exception e, bool noPrompt = true)
        {
            Consoler.ShowError(e, noPrompt);
            if (noPrompt) Environment.Exit(0);
        }

        public static void ShowPauseAndExit(bool noPrompt = true)
        {
            Consoler.Pause(noPrompt);
            if (noPrompt) Environment.Exit(0);
        }
    }
}
