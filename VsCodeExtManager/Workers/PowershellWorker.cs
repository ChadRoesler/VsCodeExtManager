using System.Diagnostics;

namespace VsCodeExtManager.Workers
{
    public static class PowershellWorker
    {
        public static string ExecutePowershell(string args, out string errorOutputs)
        {
            var cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "powershell.exe";
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
