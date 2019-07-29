using System;
using System.IO;
using System.Collections.Generic;

using ZeroFormatter;

namespace PrivateLocatedPackageManager
{
    /// <summary>
    /// 
    /// This class stores the info of the package.
    /// 
    /// </summary>
    [ZeroFormattable]
    public class PackageInfo
    {
        [Index(0)]
        public string Name { get; set; }

        [Index(1)]
        public Guid Identification { get; set; }

        [Index(2)]
        public string Description { get; set; }

        [Index(3)]
        public IList<string> Files { get; set; }

        /// <summary>
        /// 
        /// Save this contents to the "PLPM package info" file.
        /// 
        /// </summary>
        public void SaveInfo()
        {
            var bytes = ZeroFormatterSerializer.Serialize(this);

            var packageLocation = Path.Combine(PackageInfoDirPath, $"{Name}.plpminfo");
            File.WriteAllBytes(packageLocation, bytes);
        }

        // ----- Static Contents -----

        [IgnoreFormat]
        private static string PackageInfoDirPath
        {
            get
            {
                var appDataDirPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "PLPM"
                );
                return appDataDirPath;
            }
        }

        /// <summary>
        /// 
        /// Load an instance of PackageInfo from the "PLPM package info" file.
        /// 
        /// </summary>
        /// <param name="packageName">Package name</param>
        /// <returns>An instance of PackageInfo</returns>
        public static PackageInfo LoadInfo(string packageName)
        {
            var packageLocation = Path.Combine(PackageInfoDirPath, $"{packageName}.plpminfo");
            var bytes = File.ReadAllBytes(packageLocation);

            var info = ZeroFormatterSerializer.Deserialize<PackageInfo>(bytes);

            return info;
        }
    }
}