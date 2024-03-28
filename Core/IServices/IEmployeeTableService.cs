using Core.Models;
using Core.ViewModels;

namespace Core.Services
{
    public interface IEmployeeTableService
    {
        Task<IEnumerable<EmployeeTableOptionsResourceVM>> Get();
        Task<EmployeeTable> Create(SaveEmployeeTableResourceVM newModel);
        Task<IEnumerable<EmployeeTable>> CreateMultiple(List<SaveEmployeeTableResourceVM> newModel);
        Task<EmployeeTable> SingleOrDefaultAsync(int id);
        Task<EmployeeTableOptionsResourceVM> SingleOrDefaultAndSelectAsync(int id);
        Task Update(EmployeeTable modelToBeUpdated, SaveEmployeeTableResourceVM model);
        Task Delete(EmployeeTable model);
    }
}
