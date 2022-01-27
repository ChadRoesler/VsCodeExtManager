using Xunit;
using VsCodeExtManager.Workers;
using VsCodeExtManager.Models;
using System.Collections.Generic;
using System;
using System.IO;

namespace VsCodeExtManagerTests
{
    public class VsCodeExtManagerUnitTests
    {
        [Fact]
        public void ExtractInstalledTest()
        {
            var testOutput = "ChadRoesler.ThisExtension@0.0.1\nChadRoesler.ThatExtension@1.2.3";
            var validDict = new Dictionary<string, Version>(){
                {"chadroesler.thisextension", new Version(0,0,1) },
                {"chadroesler.thatextension", new Version(1,2,3) },
            };
            var extractedDict = ExtensionWorker.ExtractInstalledExtensions(testOutput);
            Assert.Equal(validDict, extractedDict);
        }

        [Fact]
        public void ExtensionTest()
        {
            var testFileInfo = new FileInfo("C:\\SomeDirectory\\ChadRoesler.TheOtherThingExtension-4.3.0.vsix");
            var validExtensionInfo = new ExtensionInfo()
            {
                Name = "TheOtherThingExtension",
                ExtensionPath = "C:\\SomeDirectory\\ChadRoesler.TheOtherThingExtension-4.3.0.vsix",
                VersionInRepo = new Version(4,3,0),
                VsCodeId = "ChadRoesler.TheOtherThingExtension",
                Author = "ChadRoesler"
            };
            var extensionInfo = new ExtensionInfo(testFileInfo);
            Assert.Equal(validExtensionInfo.Name, extensionInfo.Name);
            Assert.Equal(validExtensionInfo.ExtensionPath, extensionInfo.ExtensionPath);
            Assert.Equal(validExtensionInfo.VersionInRepo, extensionInfo.VersionInRepo);
            Assert.Equal(validExtensionInfo.VsCodeId, extensionInfo.VsCodeId);
            Assert.Equal(validExtensionInfo.Author, extensionInfo.Author);
        }
    }
}