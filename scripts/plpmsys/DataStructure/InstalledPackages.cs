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
            var json = File.ReadAllText(GetFileName(dirPath));

            var obj = JsonConvert.DeserializeObject<InstalledPackages>(json);

            return obj;
        }

        private static string GetFileName(string dirPath) => Path.Combine(dirPath, "plpm.json");
    }
}
