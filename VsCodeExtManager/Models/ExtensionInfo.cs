using System;

namespace VsCodeExtManager.Models
{
    internal class ExtensionInfo
    {
        internal string Name { get; set; }
        internal string ExtensionPath { get; set; }
        internal bool Installed { get; set; }
        internal string Description { get; set; }
        internal Version VersionInstalled { get; set; }
        internal Version VersionInRepo { get; set; }
        internal string VsCodeId { get; set; }
    }
}
