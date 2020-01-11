using System.Collections.Generic;
using System.Linq;

namespace WmiParser
{
    public interface IWmiInfoParser
    {
        List<IGrouping<int, KeyValuePair<string, string>?>> Parse(string wmiConsoleInfo, int propertiesCount);
    }
}