using System;
using System.Diagnostics;

namespace DatabaseMinder
{
    public static class Consoler
    {
        public static void ShowHeader(string text, string about = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("");
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            if (!string.IsNullOrEmpty(about))
            {
                Console.WriteLine("");
                Console.WriteLine(about);
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("");
        }

        public static void Title(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------");
            Console.WriteLine(text);
            Console.WriteLine("------------------------");
        }

        public static void TitleStart(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void TitleEnd(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.WriteLine("------------------------");
            Console.WriteLine("");
        }

        public static void Write(string text)
        {
            Console.WriteLine(text);
            Trace.WriteLine(text);
        }

        public static void Write(string format, object arg)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(format, arg);
        }

        public static void Warn(string text, string message = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-- WARN --");
            Console.WriteLine(text);
            if (!string.IsNullOrEmpty(message))
            {
                Write(message);
            }
        }

        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("-- ERROR --");
            Console.WriteLine(text);
        }

        public static void Success(bool noPrompt = false)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Success");
            Console.WriteLine("");
            Pause(noPrompt);
        }

        public static void ShowError(Exception e, bool noPrompt = false)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("");
            Console.WriteLine(e.Message);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(e);
            Pause(noPrompt);
        }


        public static void Pause(bool noPrompt = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Write("");
            Write("\nPress any key to exit.");
            if (noPrompt) return;
            Console.ReadLine();
        }
    }
}
