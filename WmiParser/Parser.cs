using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WmiParser
{
    public class Parser : IWmiInfoParser
    {
        public List<IGrouping<int, KeyValuePair<string, string>?>> Parse(string wmiConsoleInfo, int propertiesCount)
        {
            var c = 0;
            var wmiItems = wmiConsoleInfo
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(CreatePair)
                .Where(x => x != null)
                .GroupBy(x => c++ / propertiesCount)
                .ToList();
            return wmiItems;
        }

        private static KeyValuePair<string, string>? CreatePair(string x)
        {
            var strings = x.Split("=");
            if (strings.Length != 2)
                return null;
            var key = strings[0].Trim();
            var value = strings[1].Trim();
            return new KeyValuePair<string, string>(key, value);
        }
    }
}
