namespace WmiParser
{
    public interface IWmiInfoParser
    {
        string Parse(string wmiConsoleInfo, int propertiesCount);
    }
}