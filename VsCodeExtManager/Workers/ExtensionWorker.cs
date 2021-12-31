using System;
using System.Collections.Generic;
using System.IO;
using VsCodeExtManager.Constants;
using VsCodeExtManager.Models;
using log4net;
using System.Reflection;

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
                var output = PowershellWorker.ExecutePowershell(ResourceStrings.ListPluginCommand, out var errors);
                if (!string.IsNullOrEmpty(errors))
                {
                    if (errors.Contains("Warning"))
                    {
                        Log.Warn(errors);
                    }
                    else
                    {
                        Log.Error(errors);
                        throw new Exception(string.Format(ErrorStrings.ExtensionLoad, errors));
                    }
                }
                else
                {
                    foreach (var outputLine in output.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        outputDict.Add(outputLine.Substring(outputLine.IndexOf('.') + 1, outputLine.LastIndexOf('@') - outputLine.IndexOf('.') - 1), Version.Parse(outputLine.Substring(outputLine.LastIndexOf('@') + 1)));
                    }
                    if (Directory.Exists(DirectoryPath))
                    {
                        var extensionDirectoryInfo = new DirectoryInfo(DirectoryPath);
                        foreach (var file in extensionDirectoryInfo.GetFiles("*.vsix"))
                        {
                            var extension = new ExtensionInfo
                            {
                                Name = file.Name.Substring(file.Name.IndexOf('.') + 1, file.Name.LastIndexOf('-') - file.Name.IndexOf('.') - 1),
                                Description = File.Exists(file.FullName.Replace(".vsix", ".vsixd")) ? File.ReadAllText(file.FullName.Replace(".vsix", ".vsixd")) : ResourceStrings.NoDescription,
                                VersionInRepo = Version.Parse(file.Name.Substring(file.Name.LastIndexOf('-') + 1).Replace(file.Extension, "")),
                                ExtensionPath = file.FullName,
                                VsCodeId = file.Name.Substring(0, file.Name.LastIndexOf('-'))
                            };
                            extension.Installed = outputDict.ContainsKey(extension.Name.ToLower());
                            extension.VersionInstalled = outputDict.ContainsKey(extension.Name.ToLower()) ? outputDict[extension.Name.ToLower()] : null;
                            extensionList.Add(extension);
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format(ErrorStrings.UnableToLocateDir, DirectoryPath));
                    }
                    if(extensionList.Count == 0)
                    {
                        throw new Exception(string.Format(ErrorStrings.UnableToLocateExt, DirectoryPath));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return extensionList;
        }

        internal static string InstallExtension(ExtensionInfo extensionInfo)
        {
            var output = string.Empty;
            try
            {
                output = PowershellWorker.ExecutePowershell(string.Format(ResourceStrings.InstallPluginCommand, extensionInfo.ExtensionPath), out var errors);
                Log.Info(output);
                if (!string.IsNullOrEmpty(errors))
                {
                    if (errors.Contains("Warning"))
                    {
                        Log.Warn(errors);
                    }
                    else
                    {
                        Log.Error(errors);
                        throw new Exception(string.Format(ErrorStrings.ExtensionInstall, extensionInfo.Name, errors));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        internal static string UninstallExtension(ExtensionInfo extensionInfo)
        {
            var output = string.Empty;
            try
            {
                output = PowershellWorker.ExecutePowershell(string.Format(ResourceStrings.UninstallPluginCommand, extensionInfo.VsCodeId), out var errors);
                Log.Info(output);
                if (!string.IsNullOrEmpty(errors))
                {
                    if (errors.Contains("Warning"))
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
