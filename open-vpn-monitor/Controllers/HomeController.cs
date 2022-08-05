using Microsoft.AspNetCore.Mvc;

namespace OpenVPNMonitor.Controllers;

[Route("home")]
public class HomeController : Controller
{
    [HttpGet]
    [Route("index")]
    public ActionResult<string> Index()
    {
        return "kek";
    }
}