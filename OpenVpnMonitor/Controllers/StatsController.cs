using Microsoft.AspNetCore.Mvc;
using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.Domain.Models.StatsModels;
using OpenVpnMonitor.Services.StatsService;

namespace OpenVpnMonitor.Controllers;

[ApiController]
[Route("api/stats")]
public class StatsController : ControllerBase
{
    private readonly IStatsService _statsService;

    public StatsController(IStatsService statsService)
    {
        _statsService = statsService;
    }

    [HttpPost]
    public async Task<ActionResult<GetStatsByPeriodResponseModel>> GetStatsByPeriod([FromBody] GetStatsByPeriodRequestModel requestModel)
    {
        var data = await _statsService.GetStatisticsPerPeriod(requestModel.From, requestModel.To);
        var result = new GetStatsByPeriodResponseModel(data);
        return Ok(result);
    }
}