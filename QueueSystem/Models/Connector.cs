using Microsoft.AspNetCore.Mvc;

namespace QueueSystem.Models;

public class Connector
{
    public Connector(string name, int pin, Host host)
    {
        UserName = name;
        Pin = pin;
        Instance = this;
        Host = host;
        GameCode = "poop";
    }

    public string UserName { get; set; }
    public Host Host { get; set; }
    public int Pin { get; set; }

    public string GameCode { get; set; }
    public Connector Instance { get; set; }
    
}