using System.IO;

namespace PrivateLocatedPackageManager.CUI
{
    class InstallCommand : ICommand
    {
        public string Name => "install";

        public string Usage => "plpm install [package name]";

        public string Description => "Install the package here.";

        public void Execute(string[] args)
        {
            if(args.Length < 1)
            {
                LogTracer.LogError("[ERROR] The command, \"plpm install\" requires 1 arg.");
            }
            else
            {
                var pkgname = args[0];
                var installer = new PackageInstaller();

                //
                // Install it.
                //
                var current_dir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
                installer.Install(pkgname, current_dir);
            }
        }
    }
}