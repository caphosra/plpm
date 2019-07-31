using System;
using System.Linq;

namespace PrivateLocatedPackageManager.CUI
{
    static class Program
    {
        static ICommandFinder finder;

        static void Main(string[] args)
        {
            Init();

            if(args.Length == 0)
            {
                Console.WriteLine("Private Located Package Manager (c) 2019 Akihisa Yagi");
                Console.WriteLine();
                Console.WriteLine("[INFO] There are no args. We will run \"plpm help\".");
                ExecuteCommand(new [] {"help"});
            }
            else
            {
                ExecuteCommand(args);
            }
        }

        static void Init()
        {
            LogTracer.OnLogWrote += Console.WriteLine;
            LogTracer.OnErrorLogWrote += (text) => 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(text);
                Console.ResetColor();
            };
        }

        static void ExecuteCommand(string[] args)
        {
            if(finder == null)
            {
                finder = new CommandFinder();
                finder.Initialize();
            }

            var command = finder.Search(args[0]);
            if(command == null)
            {
                Console.Error.WriteLine($"[ERROR] A command, \"{args[0]}\" is not found.");
            }
            else
            {
                command.Execute(args.Skip(1).ToArray());
            }
        }
    }
}
