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
            ProvideHelpIfRequested(command);
            SetupServer(command);
            EnsureDirectoriesExist(command.SaveDirectory, command.XfromDirectory);
            DoBackup();
            
        }

        private static void DoBackup()
        {
            if (!_command.Backup)
            {
                return;
            }

            Consoler.Write("Backup requested...");
            var backup = new Backup
            {
                CredentialName = _command.NameOfCredentials,
                Database =GetDatabaseName()
                //EncryptionOption = new BackupEncryptionOptions(BackupEncryptionAlgorithm.Aes128,BackupEncryptorType.ServerCertificate, "AutoBackup_Certificate")
            };
            backup.Devices.AddDevice(_command.FullSavePath, DeviceType.File);
            backup.SqlBackup(_server);

            //// Backup Tail Log to Url
            //var backupTailLog = new Backup();
            //backupTailLog.CredentialName = _command.NameOfCredentials;
            //backupTailLog.Database = _command.DatabaseName;
            //backupTailLog.Action = BackupActionType.Log;
            //backupTailLog.NoRecovery = true;
            //backupTailLog.Devices.AddDevice(_command.FileName, DeviceType.Url);
            //backupTailLog.SqlBackup(server);
        }

        private static string GetDatabaseName()
        {
            var db = _command.DatabaseName;
            if (string.IsNullOrEmpty(db))
            {
                return _command.FileName.WithoutExtension();
            }

            return db;
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

        public static void ProvideHelpIfRequested(CommandArgs command)
        {
            if (!command.Help) return;
            Message.ShowHelpAndExit(command.PromptsEnabled);
        }

        public static void RestoreDatabaseFromFolder(string databaseName, string backupPath)
        {
            Consoler.Write(backupPath);
            foreach (var file in Directory.EnumerateFiles(backupPath, "*.bak").OrderBy(x => x))
            {
                try
                {
                    Consoler.Write(file);
                    RestoreDatabase(databaseName, file);
                }
                catch (Exception ex)
                {
                    Consoler.Warn("bak restore failed", backupPath);
                    Consoler.Error(ex.ToString());
                }
            }
        }

        public static void RestoreDatabase(string databaseName, string filePath)
        {

            //If the database doesn't exist, create it so that we have something
            //to overwrite.
            if (!_server.Databases.Contains(databaseName))
            {
                var database = new Database(_server, databaseName);
                database.Create();
            }

            var targetDatabase = _server.Databases[databaseName];
            targetDatabase.RecoveryModel = RecoveryModel.Simple;
            targetDatabase.Alter();
            Restore restore = new Restore();

            var backupDeviceItem = new BackupDeviceItem(filePath, DeviceType.File);
            restore.Devices.Add(backupDeviceItem);
            restore.Database = databaseName;
            restore.ReplaceDatabase = true;
            restore.Action = RestoreActionType.Database;

            var fileList = restore.ReadFileList(_server);

            // restore to new location
            var dataFile = new RelocateFile
            {
                LogicalFileName = fileList.Rows[0][0].ToString(),
                PhysicalFileName = Path.Combine(_command.XfromDirectory, _command.DatabaseName.WithoutExtension() + ".mdf")
            };

            var logFile = new RelocateFile
            {
                LogicalFileName = fileList.Rows[1][0].ToString(),
                PhysicalFileName = Path.Combine(_command.XfromDirectory, _command.DatabaseName.WithoutExtension() + "_log.log")
            };

            restore.RelocateFiles.Add(dataFile);
            restore.RelocateFiles.Add(logFile);

            _server.KillAllProcesses(databaseName);

            restore.SqlRestore(_server);
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
