using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WmiParser
{
    public class WmiInfoProvider
    {
        private readonly IWmiInfoParser _infoParser;

        public WmiInfoProvider(IWmiInfoParser infoParser)
        {
            _infoParser = infoParser;
        }
        public WmiObjects GetWmiInfo(string className, string[] properties)
        {
            var wmiInfo = RunWmiProcess(className, properties);
            return _infoParser.Parse(wmiInfo, properties.Length);
        }
        private static string RunWmiProcess(string className, IEnumerable<string> properties)
        {
            try
            {
                var props = string.Join(",", properties);
                var cmd = $"path {className} get {props} /VALUE";
                var psi = new ProcessStartInfo("wmic.exe")
                {
                    Arguments = cmd,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                var process = Process.Start(psi);
                process?.WaitForExit();
                return process?.StandardOutput.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
