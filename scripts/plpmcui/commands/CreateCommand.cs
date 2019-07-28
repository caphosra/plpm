using System;
using System.IO;
using System.Linq;

using GlobExpressions;

namespace PrivateLocatedPackageManager.CUI
{
    class CreateCommand : ICommand
    {
        public string Name => "create";

        public string Usage => "plpm create [name] [glob]";

        public string Description => "Create a package from files.";

        public void Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("[ERROR] The command, \"plpm create\" requires 2 args.");
            }
            else
            {
                var name = args[0];
                var glob = args[1];

                var currentDir = new Uri(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar);
                var matchedFiles = Glob.Files(currentDir.OriginalString, glob)
                    .Select(file => Path.Combine(currentDir.OriginalString, file));

                Console.WriteLine($"[INFO] {matchedFiles.Count()} files found.");

                var props = new PackageProps(name);
                foreach (var file in matchedFiles)
                {
                    //
                    // Get a relative path
                    //
                    var relativeUri = currentDir.MakeRelativeUri(new Uri(file, UriKind.Absolute));
                    var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

                    Console.WriteLine($"[INFO] Add a file (\"{file}\"). It will be internally called as \"{relativePath}\"");

                    props.Files.Add(new PackageItem(file, relativePath));
                }

                var creater = new PackageCreater();
                creater.Build(props);
            }
        }
    }
}