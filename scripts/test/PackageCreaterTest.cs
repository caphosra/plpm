using System;
using System.IO;
using System.Collections.Generic;

using Xunit;
using Xunit.Abstractions;

namespace PrivateLocatedPackageManager.Test
{
    public class PackageCreaterTest : IDisposable
    {
        private string helloFilePath => Path.Combine(Directory.GetCurrentDirectory(), "Hello.txt");

        public PackageCreaterTest(ITestOutputHelper output)
        {
            using(var stream = File.Create(helloFilePath))
            using(var writeStream = new StreamWriter(stream))
            {
                writeStream.WriteLine("Hello World !");
            }

            LogTracer.OnLogWrote += output.WriteLine;
            LogTracer.OnErrorLogWrote += output.WriteLine;
        }

        public void Dispose()
        {
            if(File.Exists(helloFilePath))
            {
                File.Delete(helloFilePath);
            }
        }

        [Fact]
        public void CreatePackage()
        {
            var pc = new PackageCreater();
            var workingDir = new Uri(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar, UriKind.Absolute);
            var uri = new Uri("Hello.txt", UriKind.Relative);
            pc.Build("Hello", workingDir, new List<Uri>{ uri });
        }
    }
}
