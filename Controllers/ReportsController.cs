using AdminPortal.Interfaces;
using AdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AdminPortal.Controllers;

[ApiController]
[Route("reportslist")]
public class ReportsController : ControllerBase
{
    private readonly IMongoService<Report, Report> _reportService;
    public ReportsController(IMongoService<Report, Report> reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    public IEnumerable<Object> GetAll()
    {
        var reports = _reportService.FilterBy(
            _ => true, p => new 
            {
                Id = p.Id,
                JobId = p.JobId
            });
        return reports.ToList();
    }
}