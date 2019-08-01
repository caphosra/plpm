using System;
using System.IO;
using System.Linq;

namespace PrivateLocatedPackageManager.CUI
{
    class SearchCommand : ICommand
    {
        public string Name => "search";

        public string Usage => "plpm search [--local(optional)]";

        public string Description => "Show the list of all packages created.\n" +
            "When it has \"--local\", that will be replaced with the list of packages which were installed in the working directory.";

        public void Execute(string[] args)
        {
            if(args.Contains("--local"))
            {
                var current_dir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                var installed = InstalledPackages.Deserialize(current_dir);

                Console.WriteLine($"{installed.Packages.Count} packages found.");
                foreach(var package in installed.Packages)
                {
                    Console.WriteLine($"- {package.Key}");
                }
            }
            else
            {
                var finder = new PackageFinder();
                var list = finder.FindAll();

                Console.WriteLine($"{list.Count} packages found.");
                foreach(var name in list)
                {
                    Console.WriteLine($"- {name}");
                }
            }
        }
    }
}