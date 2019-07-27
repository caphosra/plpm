using System.Collections.Generic;

namespace PrivateLocatedPackageManager
{
    /// <summary>
    /// 
    /// The properties of the package.
    /// 
    /// </summary>
    public class PackageProps
    {
        /// <summary>
        /// 
        /// The name of the package.
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The files which are included in the package.
        /// </summary>
        public List<PackageItem> Files { get; set; } = new List<PackageItem>();

        public PackageProps(string name)
        {
            Name = name;
        }
    }
}