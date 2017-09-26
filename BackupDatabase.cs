using Microsoft.SqlServer.Management.Smo;

namespace DatabaseMinder
{
    public static class BackupDatabase
    {
        public static void Execute(Server server, string databaseName, string nameOfCredentials, string fullSavePath, bool CompressionEnabled = false)
        {
            
            var backup = new Backup
            {
                CredentialName = nameOfCredentials,
                Database = databaseName,
                CompressionOption = CompressionEnabled ? BackupCompressionOptions.On : BackupCompressionOptions.Off
                //EncryptionOption = new BackupEncryptionOptions(BackupEncryptionAlgorithm.Aes128,BackupEncryptorType.ServerCertificate, "AutoBackup_Certificate")
            };
            backup.Devices.AddDevice(fullSavePath, DeviceType.File);
            backup.SqlBackup(server);
            Consoler.Information($"Database backed up and saved to {fullSavePath}");

        }
    }
}
