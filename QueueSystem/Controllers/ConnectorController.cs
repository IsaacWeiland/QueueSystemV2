using Microsoft.AspNetCore.Mvc;
using QueueSystem.Models;
using Connector = QueueSystem.Models.Connector;
using Host = QueueSystem.Models.Host;

namespace QueueSystem.Controllers;

public class ConnectorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult WaitingRoom(string userName, int pinNumber)
    {

        if (Tracker.CheckPin(pinNumber))
        {
            var roomHost = Tracker.GetHost(pinNumber);
            Connector user = new Connector(userName, pinNumber, roomHost);
            Tracker.ConnectorList.Add(user);
            roomHost.UserList.Add(user);
            return View(user);
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    public ActionResult GetCode(int pin, string name)
    {
        var connector = Tracker.GetConnector(pin, name);
        return PartialView("_CodePartialView", connector);
    }

    
    public JsonResult UnloadEvent(int pin, string name)
    {
        Connector connector = Tracker.GetConnector(pin, name);
        Host host = Tracker.GetHost(pin);
        host.UserList.Remove(connector);
        connector.EndInstance(connector);
        return Json(new { success = true });
    }
}