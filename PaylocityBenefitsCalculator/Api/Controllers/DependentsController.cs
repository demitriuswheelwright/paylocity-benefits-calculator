using System.Reflection;
using Api.Dtos.Dependent;
using BenefitsCalculator.Service;
using BenefitsCalculator.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    protected readonly IDependentService _dependentService;

    public DependentsController(IDependentService dependentService)
    {
        _dependentService = dependentService;
    }

    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    [Produces(typeof(ApiResponse<GetDependentDto>))]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _dependentService.GetAsync(id);

        // Here return the StatusCode based on the response directly from the service.
        // Using this method allows us to keep the controller lean, without any conditional logic.

        return StatusCode(response.StatusCode, response);
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    [Produces(typeof(ApiResponse<List<GetDependentDto>>))]
    public async Task<IActionResult> GetAll()
    {
        var response = await _dependentService.GetAllAsync();

        return StatusCode(response.StatusCode, response);
    }
}
