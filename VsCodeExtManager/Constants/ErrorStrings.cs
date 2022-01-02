namespace VsCodeExtManager.Constants
{
    internal sealed class ErrorStrings
    {
        internal const string ExtensionLoad = "The following error occured during listing installed plugins:\r\n{0}";
        internal const string UnableToLocateDir = "Unable to locate configured directory: {0}\r\nPlease validate that the directory exists and is accessable.";
        internal const string UnableToLocateExt = "Unable to locate extensions in directory: {0}\r\nPlease validate that the directory exists and is accessable and contains extensions.";
        internal const string ExtensionInstall = "The following error occured during installation of plugin {0}:\r\n{1}";
        internal const string ExtensionUninstall = "The following error occured during uninstallation of plugin {0}:\r\n{1}";
        internal const string NoExtensionPassed = "No Extension was passed for the following opperation: {0}";
    }
}
