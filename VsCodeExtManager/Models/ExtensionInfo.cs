using System;
using System.IO;
using System.Runtime.CompilerServices;
using VsCodeExtManager.Constants;

[assembly: InternalsVisibleTo("VsCodeExtManagerTests")]
namespace VsCodeExtManager.Models
{
    internal class ExtensionInfo
    {
        internal ExtensionInfo()
        {
        }

        /// <summary>
        /// Load from FileInfo
        /// </summary>
        /// <param name="file"></param>
        internal ExtensionInfo(FileInfo file)
        {
            Name = file.Name.Substring(file.Name.IndexOf('.') + 1, file.Name.LastIndexOf('-') - file.Name.IndexOf('.') - 1);
            VersionInRepo = Version.Parse(file.Name.Substring(file.Name.LastIndexOf('-') + 1).Replace(file.Extension, ""));
            ExtensionPath = file.FullName;
            VsCodeId = file.Name.Substring(0, file.Name.LastIndexOf('-'));
            Description = File.Exists(file.FullName.Replace(file.Extension, ".vsixd")) ? File.ReadAllText(file.FullName.Replace(file.Extension, ".vsixd")) : string.Format(ResourceStrings.NoDescription, Name);
            Author = file.Name.Substring(0, file.Name.IndexOf('.'));
        }
        internal string Name { get; set; }
        internal string ExtensionPath { get; set; }
        internal bool Installed { get; set; }
        internal string Description { get; set; }
        internal Version VersionInstalled { get; set; }
        internal Version VersionInRepo { get; set; }
        internal string VsCodeId { get; set; }
        internal string Author { get; set; }
    }
}
