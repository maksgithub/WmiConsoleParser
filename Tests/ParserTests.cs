using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WmiParser;

namespace Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Parse_Str()
        {
            var infoProvider = new WmiInfoProvider(new Parser());
            var properties = new[] { "name", "SerialNumber" };
            var wmiInfo = infoProvider.GetWmiInfo("Win32_Volume", properties);
            Assert.AreEqual(wmiInfo[0].ToList()[0].Value.Value, "123");
        }
    }
}
