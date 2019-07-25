using System;
using System.IO;

namespace PrivateLocatedPackageManager
{
    public class PackageItem
    {
        public string SourceFilePath { get; set; }
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