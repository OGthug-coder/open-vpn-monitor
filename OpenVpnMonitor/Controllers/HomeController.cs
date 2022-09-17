using Microsoft.AspNetCore.Mvc;

namespace OpenVpnMonitor.Controllers;

[Route("Home")]
public class HomeController : Controller
{
    [HttpGet]
    [Route("Index")]
    public ActionResult<string> Index()
    {
        return "kek";
    }
}