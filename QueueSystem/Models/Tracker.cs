namespace QueueSystem.Models;

public static class Tracker
{
    public static List<Host> HostList { get; set; }
    public static List<Connector> ConnectorList { get; set; }

    public static Host GetHost(int inputPin)
    {
        foreach (var host in HostList)
        {
            if (inputPin == host.Pin)
            {
                return host;
            }
        }
        return null;
    }

    public static Connector GetConnector(int pin, string name)
    {
        foreach (var connector in ConnectorList)
        {
            if (connector.Pin == pin && connector.UserName == name)
            {
                return connector;
            }
        }

        return null;
    }
    public static bool CheckPin(int pin)
    {
        foreach (var host in HostList)
        {
            if (host.Pin == pin)
            {
                return true;
            }
        }
        return false;
    }
}