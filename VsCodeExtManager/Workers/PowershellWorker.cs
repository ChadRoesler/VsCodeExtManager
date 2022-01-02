using System.Diagnostics;
using VsCodeExtManager.Constants;

namespace VsCodeExtManager.Workers
{
    internal static class PowershellWorker
    {
        internal static string ExecutePowershell(string args, out string errorOutputs)
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
