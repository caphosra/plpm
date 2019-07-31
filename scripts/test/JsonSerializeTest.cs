using System;
using System.IO;

using Xunit;

namespace PrivateLocatedPackageManager.Test
{
    public class JsonSerializeTest : IDisposable
    {
        public JsonSerializeTest()
        {

        }

        public void Dispose()
        {

        }

        [Fact]
        private void JsonTest()
        {
            var pkgs = new InstalledPackages();
            pkgs.Packages.Add("Hoge", Guid.NewGuid());
            pkgs.Packages.Add("Fuga", Guid.NewGuid());
            
            Directory.CreateDirectory("TestDir");

            pkgs.Serialize("TestDir");

            pkgs = InstalledPackages.Deserialize("TestDir");
        }
    }
}