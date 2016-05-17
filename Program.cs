using System;
using System.Collections.Generic;
using System.Linq;
using Args;

namespace DatabaseMinder
{
    /// <summary>
    /// /f "FinPowerConnect_Production.bak"
    /// /q "D:\Sql\FinPowerConnect_Production\"
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            Message.ShowHeader();

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
                Consoler.Write("{0}{0}No args passed to setup{0}{0}", Environment.NewLine);
                Message.ShowHelpAndExit();
                Environment.Exit(1);
            }

            Consoler.Write("{0}{0}Args received{0}", Environment.NewLine);

            var cleaned = CleanArgs(args);
            var command = Configuration.Configure<CommandArgs>().CreateAndBind(cleaned);
            if (command == null)
            {
                Consoler.Write("Error with args");
                Environment.Exit(1);
            }

            return command;
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

