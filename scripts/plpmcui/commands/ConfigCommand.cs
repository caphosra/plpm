using System;
using System.IO;

namespace PrivateLocatedPackageManager.CUI
{
    class ConfigCommand : ICommand
    {
        public string Name => "config";
        
        public string Usage => "plpm config";

        public string Description => "Show the variables in this tool.";

        public void Execute(string[] args)
        {
            var appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.DoNotVerify),
                "PLPM"   
            );

            Console.WriteLine($"App Data Location: {appDataPath}");
        }
    }
}