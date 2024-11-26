using Microsoft.AspNetCore.Mvc;
using QueueSystem.Models;
using Host = QueueSystem.Models.Host;

namespace QueueSystem.Controllers;

public class HostController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Room(string hostName)
    {
        Host host = new Host(hostName);
        Tracker.HostList.Add(host);
        return View(host);
    }

    public ActionResult GetPlayerList(int pin)
    {
        var host = Tracker.GetHost(pin);
        return PartialView("_PlayerListPartialView", host);
    }

    public void SendGameCode(string code, int players, int pin)
    {
        var host = Tracker.GetHost(pin);
        for (int i = 0; i < players; i++)
        {
            host.UserList[i].GameCode = code;
        }
    }

    public IActionResult TrackerPage()
    {
        try
        {
            return View();
        }
        catch (Exception)
        {
            return RedirectToAction("Index", "Home");
        }
        
    }

    public ActionResult GetAllLists()
    {
        return PartialView("_TrackerPartialView");
    }
}