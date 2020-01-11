using System.Collections.Generic;
using System.Linq;

namespace WmiParser
{
    public interface IWmiInfoParser
    {
        WmiObjects Parse(string wmiConsoleInfo, int propertiesCount);
    }
}