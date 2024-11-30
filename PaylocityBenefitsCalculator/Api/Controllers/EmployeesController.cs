using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using BenefitsCalculator.Service;
using BenefitsCalculator.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    protected readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    [Produces(typeof(ApiResponse<GetEmployeeDto>))]
    public async Task<IActionResult> Get(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// I try to return interfaces or base classes as often as possible.
    /// I'm assuming the reason we're using the concrete class of ActionResult was to make
    /// it clear what the endpoint returns, which we can accomplish by the [Produces] attribute.
    /// </summary>
    /// <returns></returns>
    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    [Produces(typeof(ApiResponse<List<GetEmployeeDto>>))]
    public async Task<IActionResult> GetAll()
    {
        //task: use a more realistic production approach
        

        var result = new ApiResponse<List<GetEmployeeDto>>
        {
            Data = employees,
            Success = true
        };

        return result;
    }
}
