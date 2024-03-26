using Core.Models;
using Core.ViewModels;

namespace Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeOptionsResourceVM>> Get();
        Task<IEnumerable<EmployeeOptionsResourceVM>> NonAssignedAsync(int tableId);
        Task<IEnumerable<GetEmployeeVM>> GetAll();
        Task<Employee> Create(SaveEmployeeResourceVM newModel);
        Task<EmployeeResourceVM> SingleOrDefaultAndSelectAsync(Guid id);
        Task<Employee> SingleOrDefaultAsync(Guid id);
        Task Update(Employee modelToBeUpdated, UpdateEmployeeResourceVM model);
        Task Delete(Employee model);
    }
}
