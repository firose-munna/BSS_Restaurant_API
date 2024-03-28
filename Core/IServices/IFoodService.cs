using Core.Models;
using Core.ViewModels;

namespace Core.Services
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodOptionsResourceVM>> Get();
        Task<IEnumerable<GetFoodDataVM>> GetAll();
        Task<Food> SingleOrDefaultAsync(int id);
        Task<FoodResourceVM> SingleOrDefaultAndSelectAsync(int id);
        Task<Food> Create(FoodResourceVM newModel);
        Task<IEnumerable<Food>> CreateRange(IEnumerable<Food> newModels);
        Task Update(Food modelToBeUpdated, UpdateFoodResourceVM model);
        Task Delete(Food model);
    }
}
