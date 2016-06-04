using System;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.Management.Smo;

namespace DatabaseMinder
{
    public static class Handler
    {
        private static Server _server;
        private static CommandArgs _command;

        public static void HandleCommand(CommandArgs command)
        {
            _command = command;
            ShowHelp(command);
            SetupServer(command);
            EnsureDirectoriesExist(command.Folder, command.XfromDirectory);
            DoBackup();
            DoRestore();
        }

        private static void SetupServer(CommandArgs command)
        {
            var serverName = ".";

            if (!string.IsNullOrEmpty(command.ServerName))
            {
                serverName = command.ServerName;
            }
            _server = new Server(serverName);
            _server.ConnectionContext.StatementTimeout = 0;
        }

        public static void ShowHelp(CommandArgs command)
        {
            if (!command.Help) return;
            Message.ShowHelpAndExit(command.PromptsEnabled);
        }

        private static void DoBackup()
        {
            if (!_command.Backup)
            {
                return;
            }

            Consoler.Write("Backup requested...");
            BackupDatabase.Execute(_server, _command.DatabaseName, _command.NameOfCredentials, _command.BackFullPath);
        }

        private static void DoRestore()
        {
            if (!_command.Restore)
            {
                return;
            }

            Consoler.Write("Restore requested...");
            RestoreDatabase.Execute(_server, _command.Folder, _command.DatabaseName);
        }

        private static void EnsureDirectoriesExist(params string[] paths)
        {
            string lastPath = null;
            try
            {
                foreach (var path in paths.Where(x=>!string.IsNullOrEmpty(x)))
                {
                    lastPath = path;
                    if (!Directory.Exists(path))
                    {
                        Consoler.Information("creating directory " + path);
                        Directory.CreateDirectory(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Consoler.Error($"Cannot create directories {lastPath} ");
                Consoler.Warn(ex.Message);
                Consoler.Pause(true);
            }
        }
    }
}
