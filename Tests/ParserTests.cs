using NUnit.Framework;
using Tests.Properties;
using WmiParser;

namespace Tests
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase]
        public void Parse_BigResult()
        {
            var parser = new Parser();
            var consoleResult = Resource1.WmiConsoleResult;
            int propertiesCount = 44;
            var wmiInfo = parser.Parse(consoleResult, propertiesCount);
            Assert.AreEqual(wmiInfo[0]["BlockSize"], "4096");
            Assert.AreEqual(wmiInfo[0]["Status"], "");
            Assert.AreEqual(wmiInfo[0]["Name"], "\\\\?\\Volume{e50d7cd1-0000-0000-0000-100000000000}\\");
            Assert.AreEqual(wmiInfo[1]["Name"], "C:\\");
            Assert.AreEqual(wmiInfo[4]["Name"], "F:\\");
        }
        
        [TestCase]
        public void Parse_SingleProperty()
        {
            var parser = new Parser();
            var consoleResult = Resource1.WmiConsoleResult_SingleProp;
            int propertiesCount = 1;
            var wmiInfo = parser.Parse(consoleResult, propertiesCount);
            Assert.That(wmiInfo, Has.Count.EqualTo(5));
            Assert.AreEqual(wmiInfo[4]["DeviceID"], "\\\\?\\Volume{de76966d-2517-11e7-8209-806e6f6e6963}\\");
        }

        [TestCase]
        public void Parse_Empty()
        {
            var parser = new Parser();
            var wmiInfo = parser.Parse("", 44);
            Assert.That(wmiInfo, Is.Empty);
        }
        

        [TestCase]
        public void Parse_Null()
        {
            var parser = new Parser();
            var wmiInfo = parser.Parse(null, 34);
            Assert.That(wmiInfo, Is.Empty);
        }
    }
}
