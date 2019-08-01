using System;

namespace PrivateLocatedPackageManager.CUI
{
    class SearchCommand : ICommand
    {
        public string Name => "search";

        public string Usage => "plpm search";

        public string Description => "Show the list of all packages created.";

        public void Execute(string[] args)
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