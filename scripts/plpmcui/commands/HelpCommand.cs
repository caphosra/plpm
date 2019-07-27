using System;

namespace PrivateLocatedPackageManager.CUI
{
    class HelpCommand : ICommand
    {
        public string Name => "help";

        public string Usage => "plpm help [command name]";

        public string Description => "With this command, you can watch the help of the command you want.";

        public void Execute(string[] args)
        {
            if(args.Length == 0)
            {
                // Console.Error.WriteLine("[ERROR] The command, \"plpm help\" requires 1 or more args.");

                Console.WriteLine("You can use the following commands.");

                var finder = new CommandFinder() as ICommandFinder;
                finder.Initialize();
                var commands = finder.GetAllCommands();
                foreach(var command in commands)
                {
                    Console.WriteLine($"- plpm {command.Name} | {command.Description}");
                }
            }
            else
            {
                var finder = new CommandFinder() as ICommandFinder;
                finder.Initialize();
                var command = finder.Search(args[0]);
                if(command == null)
                {
                    Console.Error.WriteLine($"[ERROR] Not found a command, \"{args[0]}\".");
                }
                else
                {
                    Console.WriteLine($"Usage: {command.Usage}\n\n{command.Description}");
                }
            }
        }
    }
}