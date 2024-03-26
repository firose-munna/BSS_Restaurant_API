using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("get")]
        public Task<IEnumerable<EmployeeOptionsResourceVM>> Get() => _employeeService.Get();

        [HttpGet("non-assigned-employees/{tableId}")]
        public Task<IEnumerable<EmployeeOptionsResourceVM>> NonAssigned(int tableId) => _employeeService.NonAssignedAsync(tableId);

        [HttpGet("datatable")]
        public Task<IEnumerable<GetEmployeeVM>> GetAll() => _employeeService.GetAll();

        [HttpPost("create")]
        public async Task Create(SaveEmployeeResourceVM newModel)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            await _employeeService.Create(newModel);
        }

        [HttpPut("update/{id}")]
        public async Task UdpateDesignation(Guid id, [FromBody] UpdateEmployeeResourceVM updatedModel)
        {
            var currentEmployee = await _employeeService.SingleOrDefaultAsync(id) ?? throw new Exception("Employee not found");
            await _employeeService.Update(currentEmployee, updatedModel);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(Guid id)
        {
            var employeeToDelete = await _employeeService.SingleOrDefaultAsync(id) ?? throw new Exception("Food not found");
            await _employeeService.Delete(employeeToDelete);
        }

    }
}
