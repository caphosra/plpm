using System.IO.Compression;

namespace PrivateLocatedPackageManager
{
    public class PackageInstaller
    {
        public void Install(string packagePath, string installTo)
        {
            ZipFile.ExtractToDirectory(packagePath, installTo);
        }
    }
}
