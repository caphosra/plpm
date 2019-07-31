using System.IO;

namespace PrivateLocatedPackageManager.CUI
{
    class UninstallCommand : ICommand
    {
        public string Name => "uninstall";

        public string Usage => "plpm uninstall [package name]";

        public string Description => "Uninstall the package from the working directory.";

        public void Execute(string[] args)
        {
            if(args.Length < 1)
            {
                LogTracer.LogError("[ERROR] The command, \"plpm uninstall\" requires 1 arg.");
            }
            else
            {
                var pkgname = args[0];
                var installer = new PackageInstaller();

                //
                // Uninstall it.
                //
                installer.Uninstall(pkgname, Directory.GetCurrentDirectory());
            }
        }
    }
}