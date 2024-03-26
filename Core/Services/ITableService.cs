using Core.Models;
using Core.ViewModels;

namespace Core.Services
{
    public interface ITableService
    {
        Task<IEnumerable<TableOptionsResourceVM>> Get();
        Task<IEnumerable<TableResourceVM>> GetAll();
        Task<TableCreateResourceVM> Create(TableCreateResourceVM newModel);
        Task<Table> SingleOrDefaultAsync(int id);
        Task<TableResourceVM> SingleOrDefaultAndSelectAsync(int id);
        Task Update(Table modelToBeUpdated, TableCreateResourceVM model);
        Task Delete(Table model);
    }
}
