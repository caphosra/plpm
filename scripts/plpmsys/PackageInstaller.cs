using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace PrivateLocatedPackageManager
{
    public class PackageInstaller
    {
        public void Install(string packageName, string installTo)
        {
            var lists = InstalledPackages.Deserialize(installTo);
            if(lists.Packages.Keys.Contains(packageName))
            {
                LogTracer.Log($"[WARNING] The package, {packageName} is already installed there.");   
            }
            else
            {
                //
                // Get where the files will be installed to.
                //
                var packagePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "PLPM",
                    $"{packageName}.plpmpkg"
                );

                LogTracer.Log($"[INFO] Install started (Source: {packagePath})");

                //
                // Install files.
                //
                DoInstall(packagePath, installTo);

                LogTracer.Log($"[INFO] Install Finished");

                //
                // Save changes.
                //
                var info = PackageInfo.LoadInfo(packageName);
                lists.Packages.Add(packageName, info.Identification);
                lists.Serialize(installTo);
            }
        }

        private void DoInstall(string packagePath, string installTo)
        {
            ZipFile.ExtractToDirectory(packagePath, installTo);
        }

        public void Uninstall(string packageName, string installedPath)
        {
            var lists = InstalledPackages.Deserialize(installedPath);
            if(lists.Packages.Keys.Contains(packageName))
            {
                //
                // Get the info of the package which will be uninstalled.
                //
                var info = PackageInfo.LoadInfo(packageName);

                LogTracer.Log("[INFO] Uninstall Started");

                //
                // Uninstall it.
                //
                var installedUri = new Uri(installedPath); 
                DoUninstall(info, installedUri);

                LogTracer.Log("[INFO] Uninstall finished");

                //
                // Save changes.
                //
                lists.Packages.Remove(packageName);
                lists.Serialize(installedPath);
            }
            else
            {
                LogTracer.LogError($"[ERROR] The package, {packageName} is not installed there but tried to uninstall it.");
            }
        }

        private void DoUninstall(PackageInfo packageInfo, Uri installedPath)
        {
            var lists = packageInfo.Files
                .Select(file => {
                    var relativePath = new Uri(file, UriKind.Relative);
                    var absolutePath = new Uri(installedPath, relativePath);
                    return absolutePath;
                })
                .ToList();

            foreach(var file in lists)
            {
                var filePath = file.AbsolutePath;
                if(File.Exists(filePath))
                {
                    File.Delete(filePath);
                    LogTracer.Log($"[INFO] Deleted {filePath}");
                }
                else
                {
                    LogTracer.LogError($"[ERROR] Tried to delete {filePath} but it's not found.");
                    return;
                }
            }

            LogTracer.Log("[INFO] Deleted All files successfully.");
        }
    }
}
