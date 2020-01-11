using System;
using System.Collections.Generic;
using System.Linq;

namespace WmiParser
{
    public class Parser : IWmiInfoParser
    {
        public List<Dictionary<string, string>> Parse(string wmiConsoleInfo, int propertiesCount)
        {
            var c = 0;
            var strings = (wmiConsoleInfo ??= "")
                .Split(Environment.NewLine);
            var wmiItems = strings
                .Select(CreatePair)
                .Where(x => x != null)
                .GroupBy(x => c++ / propertiesCount)
                .Select(x => x.ToDictionary(k => k.Item1, k => k.Item2))
                .ToList();

            return wmiItems;
        }

        private static Tuple<string, string> CreatePair(string property)
        {
            var keyValue = property.Split("=");
            if (keyValue.Length != 2)
                return null;
            var key = keyValue[0].Trim();
            var value = keyValue[1].Trim();
            return new Tuple<string, string>(key, value);
        }
    }
}
