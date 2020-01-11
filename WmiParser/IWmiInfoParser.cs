using System.Collections.Generic;

namespace WmiParser
{
    public interface IWmiInfoParser
    {
        List<Dictionary<string, string>> Parse(string consoleInfo, int propertiesCount);
    }
}