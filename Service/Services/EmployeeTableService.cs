using Core.Models;
using Core.Services;
using Core.ViewModels;
using Core;

namespace Service.Services
{
    public class EmployeeTableService : IEmployeeTableService
    {
        private readonly IUnitOfWork<EmployeeTable> _employeeTable;
        private readonly IUnitOfWork<Table> _table;

        public EmployeeTableService(IUnitOfWork<EmployeeTable> employeeTable, IUnitOfWork<Table> table)
        {
            _employeeTable = employeeTable;
            _table = table;
        }

        public async Task<EmployeeTable> Create(SaveEmployeeTableResourceVM newModel)
        {


            var employee = new EmployeeTable
            {
                EmployeeId = newModel.EmployeeId,
                TableId = newModel.TableId
            };
            await _employeeTable.Entity.AddAsync(employee);
            _employeeTable.Commit();
            return employee;
        }

        public async Task<IEnumerable<EmployeeTable>> CreateMultiple(List<SaveEmployeeTableResourceVM> newModel)
        {
            var employee = new List<EmployeeTable>();

            foreach (var employ in newModel)
            {
                employee.Add(new EmployeeTable
                {
                    EmployeeId = employ.EmployeeId,
                    TableId = employ.TableId
                });
            }

            await _employeeTable.Entity.AddRangeAsync(employee);
            _employeeTable.Commit();
            return employee;
        }

        public async Task Delete(EmployeeTable model)
        {
            _employeeTable.Entity.Remove(model);
            await _employeeTable.CommitAsync();
        }

        public async Task<IEnumerable<EmployeeTableOptionsResourceVM>> Get()
        {


            return await _employeeTable.Entity.GetAndSelectAsync(it => new EmployeeTableOptionsResourceVM
            {
                EmployeeTableId = it.Id,
                Employee = new EmployeeOptionsResourceVM
                {
                    EmployeeId = it.Employee.Id,
                    Name = it.Employee.User.FullName,
                },
                Table = new TableOptionsResourceVM
                {
                    TableId = it.Table.Id,
                    TableNumber = it.Table.TableNumber,
                }
            });
        }

        public async Task<EmployeeTableOptionsResourceVM> SingleOrDefaultAndSelectAsync(int id) => await _employeeTable.Entity.SingleOrDefaultAndSelectAsync(
            it => new EmployeeTableOptionsResourceVM
            {
                EmployeeTableId = it.Id,
            },
            it => it.Id == id
            );

        public async Task<EmployeeTable> SingleOrDefaultAsync(int id) => await _employeeTable.Entity.SingleOrDefaultAsync(id);

        public async Task Update(EmployeeTable modelToBeUpdated, SaveEmployeeTableResourceVM model)
        {
            modelToBeUpdated.EmployeeId = model.EmployeeId;
            modelToBeUpdated.TableId = model.TableId;
            await _employeeTable.CommitAsync();
        }
    }
}
