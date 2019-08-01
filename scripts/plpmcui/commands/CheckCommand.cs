using System;
using System.Linq;
using System.IO;

namespace PrivateLocatedPackageManager.CUI
{
    class CheckCommand : ICommand
    {
        public string Name => "check";

        public string Usage => "plpm check [package name] [--local(optional)]";

        public string Description => "Show the properties of the package which you selected.\n" +
            "You can use this at working directory by adding a option \"--local\".";

        public void Execute(string[] args)
        {
            var isLocal = false;

            if(args.Contains("--local"))
            {
                isLocal = true;
                args = args.Where(arg => arg != "--local")
                    .ToArray();
            }

            if(args.Length < 1)
            {
                LogTracer.LogError("[ERROR] The command, \"plpm check\" requires 1 arg.");
                return;
            }

            var package_name = args[0];

            if(isLocal)
            {
                var current_dir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                var installed = InstalledPackages.Deserialize(current_dir);
                var packageID = installed.Packages.FirstOrDefault(pkg => pkg.Key == package_name).Value;
                var is_latest = PackageInfo.LoadInfo(package_name).Identification == packageID;

                Console.WriteLine($"Package name : {package_name}");
                Console.WriteLine($"Package ID : {packageID}");
                Console.WriteLine($"Is latest : {is_latest}");
            }
            else
            {
                var info = PackageInfo.LoadInfo(package_name);
                
                Console.WriteLine($"Package name : {package_name}");
                Console.WriteLine($"Package ID : {info.Identification}");
                Console.WriteLine($"Description : {info.Description}");
                Console.WriteLine($"Files : |");
                foreach(var file in info.Files)
                {
                    Console.WriteLine($"- {file}");
                }
            }
        }
    }
}