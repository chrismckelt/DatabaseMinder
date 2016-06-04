using System;
using System.Collections.Generic;
using System.Linq;
using Args;
using Serilog;
using System.Configuration;

namespace DatabaseMinder
{
    /// <summary>
    /// see app.config for switches
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            Message.ShowHeader();
            string logFileName = $"log.log";
            Log.Logger = new LoggerConfiguration()
               // .WriteTo.ColoredConsole()
                .WriteTo.RollingFile($"{AppDomain.CurrentDomain.BaseDirectory}\\logs\\{logFileName}")
                .CreateLogger();

            Log.Logger.Information("Database minder started...");

            var command = ParseArgs(args);

            try
            {
                Handler.HandleCommand(command);
            }
            catch (Exception ex)
            {
                Message.ShowErrorAndExit(ex, command.PromptsEnabled);
            }

            Message.ShowCompletedAndExit(command.PromptsEnabled);
        }

        public static CommandArgs ParseArgs(string[] args)
        {
            if (!args.Any())
            {
                Consoler.Write("No args passed to setup", Environment.NewLine);
                Message.ShowHelpAndExit();
                Environment.Exit(1);
            }

            Consoler.Write("Args received");

            var cleaned = CleanArgs(args);
            var command = Args.Configuration.Configure<CommandArgs>().CreateAndBind(cleaned);
            if (command == null)
            {
                Consoler.Write("Error with args");
                Environment.Exit(1);
            }

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableArgsModeViaConfig"]))
            {
                Consoler.Write("EnableArgsModeViaConfig == true");
                LoadArgsFromConfig(command);
            }

            return command;
        }

        private static void LoadArgsFromConfig(CommandArgs command)
        {
            command.Backup = Convert.ToBoolean(ConfigurationManager.AppSettings["Backup"]);
            command.Restore = Convert.ToBoolean(ConfigurationManager.AppSettings["Restore"]);
            command.PromptsEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["PromptsEnabled"]);

            if (string.IsNullOrEmpty(command.DatabaseName))
            {
                command.DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
            }

            if (string.IsNullOrEmpty(command.Folder))
            {
                command.Folder = ConfigurationManager.AppSettings["Folder"];
            }

            if (string.IsNullOrEmpty(command.FileName))
            {
                command.FileName = string.Format(ConfigurationManager.AppSettings["FileName"], DateTime.Now.ToString("yyyyMMdd"));
            }

            if (string.IsNullOrEmpty(command.NameOfCredentials))
            {
                command.NameOfCredentials = ConfigurationManager.AppSettings["NameOfCredentials"];
            }

            if (string.IsNullOrEmpty(command.ConnectionString))
            {
                command.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            }
        }

        /// <summary>
        ///     build script coming in from powershell was keeping the ,,,,,,,   so having to strip them
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IEnumerable<string> CleanArgs(IEnumerable<string> args)
        {
            var cleaned = new List<string>();
            foreach (var s in args)
            {
                Consoler.Write(s);
                cleaned.Add(s.Replace(",", ""));
            }
            Consoler.Write("{0}{0}", Environment.NewLine);
            return cleaned;
        }
    }
}

