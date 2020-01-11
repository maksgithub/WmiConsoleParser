﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WmiParser
{
    public class WmiObjects : List<IGrouping<int, KeyValuePair<string, string>?>>
    {
        public WmiObjects(IEnumerable<IGrouping<int, KeyValuePair<string, string>?>> wmiItems)
        {
            AddRange(wmiItems);
        }
    }
    public class Parser : IWmiInfoParser
    {
        public WmiObjects Parse(string wmiConsoleInfo, int propertiesCount)
        {
            var c = 0;
            var wmiItems = wmiConsoleInfo
                .Split(Environment.NewLine)
                .Select(CreatePair)
                .Where(x => x != null)
                .GroupBy(x => c++ / propertiesCount)
                .ToList();
            var t = JsonConvert.SerializeObject(wmiItems);
            return new WmiObjects(wmiItems);
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