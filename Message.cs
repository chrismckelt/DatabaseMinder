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
            Consoler.ShowHeader("Database Minder", sb.ToString());
        }

        public static void ShowHelpAndExit(bool noPrompt = false)
        {
            Consoler.Title("Usage:");
            Consoler.Write("/help\t\t\tShow help");
            Consoler.Write("");
            Consoler.Write("Example:");
            Consoler.Write("");
            Consoler.Write(@"DatabaseMinder.exe /b /u /c CONNECTION STRING GOES HERE");
            Consoler.Write("");
            Consoler.Write("Arguments:");
            Consoler.Write("");
          //  Consoler.Write("\t/s ServerName - eg localhost");
            Consoler.Write("\t/f Filename - eg ExampleDatabase.bak  ExampleZip.zip");
            Consoler.Write("\t/r Restore - Restore database");
            Consoler.Write("\t/b Backup - Backup database. Server name and Folder required");
            //Consoler.Write("\t/c ConnectionString - for backups / restore");
            Consoler.Write("\t/d DatabaseName - backup / restore name for the DB");
            Consoler.Write("\t/n PromptsEnabled - Uses this flag on build server to skip any prompt");
           
            Consoler.Write("\t/t Folder");
            ShowPauseAndExit(noPrompt);
        }

        public static void ShowCompletedAndExit(bool noPrompt = false)
        {
            Consoler.Success(noPrompt);
            Environment.Exit(0);
        }

        public static void ShowErrorAndExit(Exception e, bool noPrompt = false)
        {
            Consoler.ShowError(e, noPrompt);
            Environment.Exit(1);
        }

        public static void ShowPauseAndExit(bool noPrompt = false)
        {
            Consoler.Pause(noPrompt);
            Environment.Exit(0);
        }
    }
}
