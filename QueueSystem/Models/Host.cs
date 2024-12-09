using System.Net.NetworkInformation;

namespace QueueSystem.Models;

public class Host
{
    public Host(string hostName)
    {
        PinGen();
        HostName = hostName;
        UserList = new List<Connector>();
        Instance = this;
    }
    public int? Pin { get; set; }
    public string? HostName { get; set; }
    public List<Connector> UserList { get; set; }
    public Host? Instance { get; set; }
    private void PinGen()
    {
        int[] pin = new int[5];
        for (int i = 0; i < 5; i++)
        {
            Random r = new Random();
            int randNum = r.Next(0,10);
            pin[i] = randNum;
        }

        string pinString = null;
        foreach (var number in pin)
        {
            pinString += $"{number}";
        }

        Pin = int.Parse(pinString);
    }

    public int MaxPlayers()
    {
        return UserList.Count;
    }

    public void EndInstance(Host host)
    {
        do
        {
            UserList.RemoveAt(0);
        } while (UserList.Count > 0);
        Tracker.HostList.Remove(host);
    }
}