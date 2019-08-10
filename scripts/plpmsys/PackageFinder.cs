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
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.DoNotVerify),
                "PLPM"   
            );

            if(Directory.Exists(appDataPath))
            {
                //
                // Get the list of plpmpkg files.
                //
                var files = Directory.GetFiles(appDataPath, "*.plpmpkg", SearchOption.AllDirectories)
                    .Select(file => Path.GetFileNameWithoutExtension(file))
                    .ToList();
                return files;
            }
            else
            {
                //
                // It runs when we doesn't found some packages.
                //
                return new List<string>();
            }
        }
    }
}