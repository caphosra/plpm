using System;
using System.IO;

using Xunit;

namespace PrivateLocatedPackageManager.Test
{
    public class OnPackageCreateUnitTest : IDisposable
    {
        public OnPackageCreateUnitTest()
        {
            using(var stream = File.Create("Hello.txt"))
            using(var writeStream = new StreamWriter(stream))
            {
                writeStream.WriteLine("Hello World !");
            }
        }

        public void Dispose()
        {
            if(File.Exists("Hello.txt"))
            {
                File.Delete("Hello.txt");
            }
        }

        [Fact]
        public void CreatePackage()
        {
            var prop = new PackageProps("Hello");
            prop.Files.Add(new PackageItem("Hello.txt", "Prop/Hello.txt"));

            var creater = new PackageCreater();
            creater.Build(prop);             
        }
    }
}
