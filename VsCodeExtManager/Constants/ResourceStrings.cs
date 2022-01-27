namespace VsCodeExtManager.Constants
{
    internal sealed class ResourceStrings
    {
        internal const string ListPluginCommand = "code --list-extensions --show-versions";
        internal const string InstallPluginCommand = "code --install-extension {0}";
        internal const string UninstallPluginCommand = "code --uninstall-extension {0}";
        internal const string NoDescription = "Unable to locate {0} vsixd file.  No description provided.";
        internal const string ExtensionDirConfigKey = "ExtensionDirectory";
        internal const string PowershellExecutable = "powershell.exe";
        internal const string WarningOutputCheck = "Warning";
        internal const string ExtDataSourceDisplayFormat = "{0}{1} - {2}";
    }
}
