using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace PrivateLocatedPackageManager
{
    public class PackageCreater
    {
        public void Build(Package pkg)
        {
            //
            // Generate a temp folder name by GUID.
            //
            var tempFolderName = Guid.NewGuid().ToString();
            var tempFolderPath = Path.Combine(Path.GetTempPath(), tempFolderName);

            //
            // Copy all files which are going to be compressed.
            //
            foreach(var file in pkg.Files)
            {
                if(!File.Exists(file.SourceFilePath))
                {
                    throw new FileNotFoundException($"[PLPM] The file which is located at {file} is not found.");
                }
                else
                {
                    //
                    // Get a temp file path.
                    //
                    var tempFilePath = Path.Combine(tempFolderPath, file.ManagedFilePath);
                    File.Copy(file.SourceFilePath, tempFilePath, overwrite: true);
                }
            }

            //
            // Compress them.
            //
            var outputFilePath = $"{pkg.Name}.plpmpkg";
            ZipFile.CreateFromDirectory(tempFolderPath, outputFilePath);
        }
    }
}
