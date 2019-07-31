using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace PrivateLocatedPackageManager
{
    /// <summary>
    /// 
    /// This class has info which is necessary to create a package.
    /// 
    /// </summary>
    [JsonObject]
    public class PackageProjectFile
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public List<string> ContentsFiles { get; set; }

        // ----- Static Contents -----

        private const string PACKAGE_ORDER_FILE_NAME = "plpmproj.json";

        /// <summary>
        /// 
        /// Load the project file.
        /// 
        /// </summary>
        /// <param name="dir">WorkingDir</param>
        /// <returns>[Warning] This value is nullable!</returns>
        public static PackageProjectFile LoadFromFile(string dir)
        {
            //
            // Get the path to the project file.
            //
            var filePath = Path.Combine(dir, PACKAGE_ORDER_FILE_NAME);

            if(File.Exists(filePath))
            {
                //
                // Read all and deserialize it.
                //
                var fileContent = File.ReadAllText(filePath);
                var project = JsonConvert.DeserializeObject<PackageProjectFile>(fileContent);

                return project;
            }
            else
            {
                LogTracer.LogError($"[ERROR] A project file \"{filePath}\" is not found.");
                return null;
            }
        }
    }
}