using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using VsCodeExtManager.Constants;
using VsCodeExtManager.Enums;
using VsCodeExtManager.Models;

[assembly: InternalsVisibleTo("VsCodeExtManagerTests")]
namespace VsCodeExtManager.Workers
{
    internal static class ExtensionWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Loads Extensions from the configured directory
        /// </summary>
        /// <param name="DirectoryPath">The Directory to gather extensions from</param>
        /// <returns>A list of extensions as objects</returns>
        internal static List<ExtensionInfo> LoadExtensions(string DirectoryPath)
        {
            var extensionList = new List<ExtensionInfo>();
            try
            {
                var output = ExtensionCommand(ExtensionCommandType.list);
                var outputDict = ExtractInstalledExtensions(output);
                if (Directory.Exists(DirectoryPath))
                {
                    var extensionDirectoryInfo = new DirectoryInfo(DirectoryPath);
                    var extensionFileArray = extensionDirectoryInfo.GetFiles("*.vsix");
                    for (int i = 0; i < extensionFileArray.Length; i++)
                    {
                        FileInfo file = extensionFileArray[i];
                        var extension = new ExtensionInfo(file);
                        extension.Installed = outputDict.ContainsKey(extension.VsCodeId.ToLower());
                        extension.VersionInstalled = outputDict.ContainsKey(extension.VsCodeId.ToLower()) ? outputDict[extension.VsCodeId.ToLower()] : null;
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

        /// <summary>
        /// Extracts the Installed extensions from the passed list
        /// </summary>
        /// <param name="installedExtensionList"></param>
        /// <returns>A ditctionay containing the VsCodeId and parsed Version</returns>
        internal static Dictionary<string, Version> ExtractInstalledExtensions(string installedExtensionList)
        {
            var extractedExtensionDict = new Dictionary<string, Version>();
            var installedExtensionArray = installedExtensionList.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < installedExtensionArray.Length; i++)
            {
                string outputLine = installedExtensionArray[i];
                extractedExtensionDict.Add(outputLine.Substring(0, outputLine.LastIndexOf('@')).ToLower(), Version.Parse(outputLine.Substring(outputLine.LastIndexOf('@') + 1)));
            }
            return extractedExtensionDict;
        }

        /// <summary>
        /// Executes the vscode cli for extension management
        /// </summary>
        /// <param name="extensonCommandType">The type of action to preform</param>
        /// <param name="extensionInfo">The extensioninfo object to work with</param>
        /// <returns>The result of the exection</returns>
        internal static string ExtensionCommand(ExtensionCommandType extensonCommandType, ExtensionInfo extensionInfo = null)
        {
            var output = string.Empty;
            var errors = string.Empty;
            try
            {
                switch (extensonCommandType)
                {
                    case ExtensionCommandType.list:
                        output = ExecutePowershell(ResourceStrings.ListPluginCommand, out errors);
                        break;
                    case ExtensionCommandType.install:
                        output = extensionInfo == null ? throw new Exception(string.Format(ErrorStrings.NoExtensionPassed, extensonCommandType.ToString())) : ExecutePowershell(string.Format(ResourceStrings.InstallPluginCommand, extensionInfo.ExtensionPath), out errors);
                        break;
                    case ExtensionCommandType.uninstall:
                        output = extensionInfo == null ? throw new Exception(string.Format(ErrorStrings.NoExtensionPassed, extensonCommandType.ToString())) : ExecutePowershell(string.Format(ResourceStrings.UninstallPluginCommand, extensionInfo.VsCodeId), out errors);
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

        /// <summary>
        /// Executes Powershell passed
        /// </summary>
        /// <param name="args">The powershell to run</param>
        /// <param name="errorOutputs">The redirected errors</param>
        /// <returns>The redirected output</returns>
        private static string ExecutePowershell(string args, out string errorOutputs)
        {
            var cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = ResourceStrings.PowershellExecutable;
            cmdProcess.StartInfo.Arguments = args;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.RedirectStandardError = true;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.Start();
            errorOutputs = cmdProcess.StandardError.ReadToEnd();
            var standardOutputs = cmdProcess.StandardOutput.ReadToEnd();
            cmdProcess.WaitForExit();
            return standardOutputs;
        }
    }
}