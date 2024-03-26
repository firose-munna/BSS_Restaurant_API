using Core.Models;
using Core.Services;
using Core.ViewModels;
using Core;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork<Order> _order;
        private readonly IUnitOfWork<OrderItem> _orderItem;
        public OrderService(IUnitOfWork<Order> order, IUnitOfWork<OrderItem> orderItem)
        {
            _order = order;
            _orderItem = orderItem;
        }


        public async Task<IEnumerable<OrderOptionsResourceVM>> Get()
        {
            return await _order.Entity.GetAndSelectAsync(it => new OrderOptionsResourceVM
            {
                OrderId = it.Id,
                OrderNumber = it.OrderNumber
            });
        }

        public async Task<Order> Create(SaveOrderResourceVM newModel)
        {

            var order = new Order
            {
                TableId = newModel.TableId,
                OrderNumber = newModel.OrderNumber,
                Amount = newModel.Amount,
                OrderTime = DateTime.Now,
            };
            await _order.Entity.AddAsync(order);
            await _order.CommitAsync();

            var orderItems = new List<OrderItem>();
            foreach (var item in newModel.Items)
            {
                orderItems.Add(new OrderItem
                {
                    FoodId = item.FoodId,
                    OrderId = order.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice,
                });
            }
            await _orderItem.Entity.AddRangeAsync(orderItems);
            _orderItem.Commit();
            return order;
        }

        public async Task Update(Order modelToBeUpdated, SaveOrderResourceVM model)
        {
            modelToBeUpdated.TableId = model.TableId;
            modelToBeUpdated.OrderNumber = model.OrderNumber;
            modelToBeUpdated.Amount = model.Amount;
            modelToBeUpdated.OrderItems = (ICollection<OrderItem>)model.Items;
            await _order.CommitAsync();
        }

        public async Task<Order> SingleOrDefaultAsync(Guid id) => await _order.Entity.SingleOrDefaultAsync(id);


        public async Task Delete(Order model)
        {
            _order.Entity.Remove(model);
            await _order.CommitAsync();
        }

        public async Task<IEnumerable<OrderResourceVM>> GetAll()
        {
            return await _order.Entity.GetAndSelectAsync(it => new OrderResourceVM
            {
                Id = it.Id,
                OrderNumber = it.OrderNumber,
                Amount = it.Amount,
                OrderStatus = it.OrderStatus,
                OrderTime = it.OrderTime,
                Table = new TableResourceVM
                {
                    Id = it.Table.Id,
                    TableNumber = it.Table.TableNumber,
                },
                OrderItems = it.OrderItems.Select(e => new OrderItemResourceVM
                {
                    Id = e.Id,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    TotalPrice = e.TotalPrice,
                    Food = new FoodResourceVM
                    {
                        Name = e.Food.Name,
                        Description = e.Food.Description,
                        Price = e.Food.Price,
                        DiscountType = e.Food.DiscountType,
                        Discount = e.Food.Discount,
                        Image = e.Food.Image,
                        DiscountPrice = e.Food.DiscountPrice,
                    },
                }).ToList()

            });
        }

        public async Task UpdateStatus(Order modelToBeUpdated, OrderStatusVM model)
        {
            modelToBeUpdated.OrderStatus = model.OrderStatusValue;
            await _order.CommitAsync();
        }
    }
}
