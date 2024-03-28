using Core.Models;
using Core.ViewModels;

namespace Core.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderOptionsResourceVM>> Get();

        Task<IEnumerable<OrderResourceVM>> GetAll();
        Task<Order> Create(SaveOrderResourceVM newModel);
        Task<Order> SingleOrDefaultAsync(Guid id);

        Task Update(Order modelToBeUpdated, SaveOrderResourceVM model);
        Task UpdateStatus(Order modelToBeUpdated, OrderStatusVM model);

        Task Delete(Order model);
    }
}
