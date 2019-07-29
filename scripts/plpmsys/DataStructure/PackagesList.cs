using System;
using System.IO;
using System.Collections.Generic;

using ZeroFormatter;

namespace PrivateLocatedPackageManager
{
    /// <summary>
    /// 
    /// This class contains the list of the packages.
    /// 
    /// </summary>
    [ZeroFormattable]
    public class PackagesList
    {
        [Index(0)]
        public IList<string> PackageNames { get; set; }

        /// <summary>
        /// 
        /// Save this to the file.
        /// 
        /// </summary>
        public void SaveToFile()
        {
            var bytes = ZeroFormatterSerializer.Serialize(this);
            
            File.WriteAllBytes(FilePath, bytes);
        }

        // ----- Static Contents -----

        [IgnoreFormat]
        private static string FilePath
        {
            get
            {
                var appDataDirPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "PLPM",
                    "info.plpmlist"
                );
                return appDataDirPath;
            }
        }

        /// <summary>
        /// 
        /// Load an instance of PackagesList from the file.
        /// 
        /// </summary>
        /// <returns>An instance of PackagesList</returns>
        public static PackagesList LoadFromFile()
        {
            var bytes = File.ReadAllBytes(FilePath);

            var pl = ZeroFormatterSerializer.Deserialize<PackagesList>(bytes);
            
            return pl;
        }
    }
}