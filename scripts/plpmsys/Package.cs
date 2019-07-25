using System.Collections.Generic;

namespace PrivateLocatedPackageManager
{
    public class Package
    {
        public string Name { get; set; }

        public List<PackageItem> Files { get; set; } = new List<PackageItem>();

        public Package(string name)
        {
            Name = name;
        }
    }
}