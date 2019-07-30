﻿using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;

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
        /// Build a package from the file and Emit an info of it.
        /// 
        /// </summary>
        /// <param name="workingDir">The absolute path of the working dir</param>
        /// <param name="files">The relative pathes from "workingDir" of the contents</param>
        /// <returns></returns>
        public PackageInfo Build(string packageName, Uri workingDir, List<Uri> files)
        {
            //
            // Generate a temp folder by GUID.
            //
            var tempFolderName = Guid.NewGuid().ToString();
            var tempFolderPath = Path.Combine(Path.GetTempPath(), tempFolderName);

            //
            // Copy all files which are going to be compressed.
            //
            foreach(var file in files)
            {
                var filesAbsoluteUri = new Uri(workingDir, file);
                if(!File.Exists(filesAbsoluteUri.AbsoluteUri))
                {
                    LogTracer.LogError($"[ERROR] The file which is located at {filesAbsoluteUri.AbsoluteUri} is not found.");
                    return null;
                }
                else
                {
                    //
                    // Get a temp file path.
                    //
                    var tempFilePath = Path.Combine(tempFolderPath, file.OriginalString);
                    var tempFilesFolderPath = Path.GetDirectoryName(tempFilePath);
                    if(!Directory.Exists(tempFilesFolderPath))
                    {
                        Directory.CreateDirectory(tempFilesFolderPath);
                    }
                    File.Copy(filesAbsoluteUri.AbsoluteUri, tempFilePath, overwrite: true);
                }
            }

            //
            // Prepare a folder for making a package.
            //
            var outputFileName = $"{packageName}.plpmpkg";
            var appDataFolderPath =  Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                "PLPM"
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

            //
            // Make an instance of PackageInfo.
            //
            var info = new PackageInfo();
            info.Name = packageName;
            info.Files = files
                .Select(uri => uri.OriginalString)
                .ToList();
            info.Identification = Guid.NewGuid();
            
            return info;
        }
    }
}
