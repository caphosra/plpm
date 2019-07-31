using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace PrivateLocatedPackageManager
{
    [JsonObject]
    public class InstalledPackages
    {
        [JsonProperty("packages")]
        public Dictionary<string, Guid> Packages { get; set; }
            = new Dictionary<string, Guid>();

        public void Serialize(string dirPath)
        {
            var json = JsonConvert.SerializeObject(this);

            File.WriteAllText(GetFileName(dirPath), json);
        }

        // ----- Static Contents -----

        public static InstalledPackages Deserialize(string dirPath)
        {
            var filePath = GetFileName(dirPath);
            
            if(File.Exists(filePath))
            {
                //
                // Deserialize from a json file.
                //
                var json = File.ReadAllText(filePath);
                var obj = JsonConvert.DeserializeObject<InstalledPackages>(json);

                return obj;
            }
            else
            {
                //
                // Create a new one.
                //
                var obj = new InstalledPackages();
                
                return obj;
            }
        }

        private static string GetFileName(string dirPath) => Path.Combine(dirPath, "plpm.json");
    }
}
