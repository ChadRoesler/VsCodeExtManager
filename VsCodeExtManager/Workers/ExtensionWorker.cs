using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using VsCodeExtManager.Constants;
using VsCodeExtManager.Enums;
using VsCodeExtManager.Models;

namespace VsCodeExtManager.Workers
{
    internal static class ExtensionWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        internal static List<ExtensionInfo> LoadExtensions(string DirectoryPath)
        {
            var extensionList = new List<ExtensionInfo>();
            try
            {
                var outputDict = new Dictionary<string, Version>();
                var output = ExtensionCommand(ExtensionCommandType.list);
                var outputSplit = output.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < outputSplit.Length; i++)
                {
                    string outputLine = outputSplit[i];
                    outputDict.Add(outputLine.Substring(outputLine.IndexOf('.') + 1, outputLine.LastIndexOf('@') - outputLine.IndexOf('.') - 1), Version.Parse(outputLine.Substring(outputLine.LastIndexOf('@') + 1)));
                }
                if (Directory.Exists(DirectoryPath))
                {
                    var extensionDirectoryInfo = new DirectoryInfo(DirectoryPath);
                    var extensionFileArray = extensionDirectoryInfo.GetFiles("*.vsix");
                    for (int i = 0; i < extensionFileArray.Length; i++)
                    {
                        FileInfo file = extensionFileArray[i];
                        var extension = new ExtensionInfo
                        {
                            Name = file.Name.Substring(file.Name.IndexOf('.') + 1, file.Name.LastIndexOf('-') - file.Name.IndexOf('.') - 1),
                            VersionInRepo = Version.Parse(file.Name.Substring(file.Name.LastIndexOf('-') + 1).Replace(file.Extension, "")),
                            ExtensionPath = file.FullName,
                            VsCodeId = file.Name.Substring(0, file.Name.LastIndexOf('-'))
                        };
                        extension.Description = File.Exists(file.FullName.Replace(".vsix", ".vsixd")) ? File.ReadAllText(file.FullName.Replace(".vsix", ".vsixd")) : string.Format(ResourceStrings.NoDescription, extension.Name);
                        extension.Installed = outputDict.ContainsKey(extension.Name.ToLower());
                        extension.VersionInstalled = outputDict.ContainsKey(extension.Name.ToLower()) ? outputDict[extension.Name.ToLower()] : null;
                        extensionList.Add(extension);
                    }
                }
                else
                {
                    throw new Exception(string.Format(ErrorStrings.UnableToLocateDir, DirectoryPath));
                }
                if (extensionList.Count == 0)
                {
                    throw new Exception(string.Format(ErrorStrings.UnableToLocateExt, DirectoryPath));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return extensionList;
        }

        internal static string ExtensionCommand(ExtensionCommandType extensonCommandType, ExtensionInfo extensionInfo = null)
        {
            var output = string.Empty;
            var errors = string.Empty;
            try
            {
                switch (extensonCommandType)
                {

                    case ExtensionCommandType.list:
                        output = PowershellWorker.ExecutePowershell(ResourceStrings.ListPluginCommand, out errors);
                        break;
                    case ExtensionCommandType.install:
                        output = extensionInfo == null ? throw new Exception(string.Format(ErrorStrings.NoExtensionPassed, extensonCommandType.ToString())) : PowershellWorker.ExecutePowershell(string.Format(ResourceStrings.InstallPluginCommand, extensionInfo.ExtensionPath), out errors);
                        break;
                    case ExtensionCommandType.uninstall:
                        output = extensionInfo == null ? throw new Exception(string.Format(ErrorStrings.NoExtensionPassed, extensonCommandType.ToString())) : PowershellWorker.ExecutePowershell(string.Format(ResourceStrings.UninstallPluginCommand, extensionInfo.VsCodeId), out errors);
                        break;
                    default:
                        break;
                };
                Log.Info(output);
                if (!string.IsNullOrEmpty(errors))
                {
                    if (errors.Contains(ResourceStrings.WarningOutputCheck))
                    {
                        Log.Warn(errors);
                    }
                    else
                    {
                        Log.Error(errors);
                        throw new Exception(string.Format(ErrorStrings.ExtensionUninstall, extensionInfo.Name, errors));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
    }
}