using System;
using System.IO;
using System.IO.Compression;

namespace PrivateLocatedPackageManager
{
    /// <summary>
    /// 
    /// Support you to generate a plpmpkg file.
    /// 
    /// </summary>
    public class PackageCreater
    {
        /// <summary>
        /// 
        /// Generate a plpmpkg file from PackagesProps.
        /// 
        /// </summary>
        /// <param name="pkg">the properties of the package</param>
        /// <returns>a path to the package generated</returns>
        public string Build(PackageProps pkg)
        {
            //
            // Generate a temp folder by GUID.
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
                    throw new FileNotFoundException($"[ERROR] The file which is located at {file} is not found.");
                }
                else
                {
                    //
                    // Get a temp file path.
                    //
                    var tempFilePath = Path.Combine(tempFolderPath, file.ManagedFilePath);
                    var tempFilesFolderPath = Path.GetDirectoryName(tempFilePath);
                    if(!Directory.Exists(tempFilesFolderPath))
                    {
                        Directory.CreateDirectory(tempFilesFolderPath);
                    }
                    File.Copy(file.SourceFilePath, tempFilePath, overwrite: true);
                }
            }

            //
            // Prepare a folder for making a package.
            //
            var outputFileName = $"{pkg.Name}.plpmpkg";
            var appDataFolderPath =  Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                "PrivateLocatedPackageManager"
            );
            if(!Directory.Exists(appDataFolderPath))
            {
                Directory.CreateDirectory(appDataFolderPath);
            }

            //
            // Compress them.
            //
            var outputFilePath = Path.Combine(appDataFolderPath, outputFileName);
            ZipFile.CreateFromDirectory(tempFolderPath, outputFilePath);

            return outputFilePath;
        }
    }
}
