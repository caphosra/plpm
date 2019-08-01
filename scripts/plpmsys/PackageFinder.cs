using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace PrivateLocatedPackageManager
{
    public class PackageFinder
    {
        /// <summary>
        /// 
        /// Find all packages which is created and Serve the list of them.
        /// 
        /// </summary>
        /// <returns>The list of the packages</returns>
        public List<string> FindAll()
        {
            var appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "PLPM"   
            );

            var files = Directory.GetFiles(appDataPath, "*.plpmpkg", SearchOption.AllDirectories)
                .Select(file => Path.GetFileNameWithoutExtension(file))
                .ToList();

            return files;
        }
    }
}