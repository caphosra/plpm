using System;
using System.IO;
using System.Linq;

namespace PrivateLocatedPackageManager.CUI
{
    class CreateCommand : ICommand
    {
        public string Name => "create";

        public string Usage => "plpm create";

        public string Description => "Create a package from files. This command requires \"plpmproj.json\".";

        public void Execute(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    {
                        var current_dir_path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                        var current_dir = new Uri(current_dir_path, UriKind.Absolute);
                        var proj = PackageProjectFile.LoadFromFile(current_dir.OriginalString);
                        var creater = new PackageCreater();

                        LogTracer.Log("[INFO] Started building package ...");

                        var info = creater.Build(current_dir, proj);
                        info.SaveInfo();

                        LogTracer.Log("[INFO] Finished building package");
                    }
                    break;
            }
        }
    }
}