using System;
using System.IO;

namespace PrivateLocatedPackageManager
{
    /// <summary>
    /// 
    /// This expresses one of the files which is contained in the package.
    /// 
    /// </summary>
    public class PackageItem
    {
        /// <summary>
        /// 
        /// The path to the source file.
        /// (It should be an absolute path.)
        ///
        /// </summary>
        public string SourceFilePath { get; set; }

        /// <summary>
        /// 
        /// The relative path from the root folder of the package to the file.
        /// 
        /// </summary>
        /// <value></value>
        public string ManagedFilePath { get; set; }

        public PackageItem(string sourceFilePath, string managedFilePath)
        {
            if(!File.Exists(sourceFilePath))
            {
                Console.Error.WriteLine($"[PLPM] Warnings: The file which is at {sourceFilePath} is not found but referenced");
            }

            SourceFilePath = sourceFilePath;
            ManagedFilePath = managedFilePath;
        }
    }
}