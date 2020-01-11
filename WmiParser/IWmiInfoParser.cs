using System.Collections.Generic;
using System.Linq;

namespace WmiParser
{
    public interface IWmiInfoParser
    {
        List<Dictionary<string, string>> Parse(string wmiConsoleInfo, int propertiesCount);
    }
}