using Microsoft.AspNetCore.Mvc;

namespace OpenVpnMonitor.Controllers;

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