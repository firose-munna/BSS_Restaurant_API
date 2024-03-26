using Core.Models;
using Core.Services;
using Core.ViewModels;
using Core;

namespace Service.Services
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork<Table> _table;
        private readonly IUnitOfWork<EmployeeTable> _employeeTable;

        public TableService(IUnitOfWork<Table> table, IUnitOfWork<EmployeeTable> employeeTable)
        {
            _table = table;
            _employeeTable = employeeTable;
        }

        public async Task<TableCreateResourceVM> Create(TableCreateResourceVM newModel)
        {
            var table = new Table
            {
                TableNumber = newModel.TableNumber,
                NumberOfSeats = newModel.NumberOfSeats,
                Image = newModel.Base64,
                IsOccupied = true,

            };
            await _table.Entity.AddAsync(table);
            _table.Commit();
            return newModel;
        }

        public async Task Delete(Table model)
        {
            _table.Entity.Remove(model);
            await _table.CommitAsync();
        }

        public async Task<IEnumerable<TableOptionsResourceVM>> Get()
        {
            return await _table.Entity.GetAndSelectAsync(it => new TableOptionsResourceVM
            {
                TableId = it.Id,
                TableNumber = it.TableNumber,

            });
        }


        public async Task<IEnumerable<TableResourceVM>> GetAll()
        {
            return await _table.Entity.GetAndSelectAsync(it => new TableResourceVM
            {
                Id = it.Id,
                TableNumber = it.TableNumber,
                Image = it.Image,
                IsOccupied = it.IsOccupied,
                NumberOfSeats = it.NumberOfSeats,
                Employees = it.EmployeeTables.Select(e => new EmployeeWithTableIdResourceVM
                {
                    EmployeeTableId = e.Id,
                    EmployeeId = e.EmployeeId,
                    Name = e.Employee.User.FullName,
                }).ToList()
            });
        }

        public async Task<TableResourceVM> SingleOrDefaultAndSelectAsync(int id)
         => await _table.Entity.SingleOrDefaultAndSelectAsync(
            it => new TableResourceVM
            {
                Id = it.Id,
                TableNumber = it.TableNumber,
                Image = it.Image,
                IsOccupied = it.IsOccupied,
                NumberOfSeats = it.NumberOfSeats,
                Employees = it.EmployeeTables.Select(e => new EmployeeWithTableIdResourceVM
                {
                    EmployeeTableId = e.TableId,
                    EmployeeId = e.EmployeeId,
                    Name = e.Employee.User.FullName,
                }).ToList()
            },
            it => it.Id == id
            );

        public async Task<Table> SingleOrDefaultAsync(int id) => await _table.Entity.SingleOrDefaultAsync(id);

        public async Task Update(Table modelToBeUpdated, TableCreateResourceVM model)
        {
            modelToBeUpdated.TableNumber = model.TableNumber;
            modelToBeUpdated.NumberOfSeats = model.NumberOfSeats;
            modelToBeUpdated.Image = model.Image;
            await _table.CommitAsync();
        }
    }
}
