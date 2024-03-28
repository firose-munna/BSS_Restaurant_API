using Core.Models;
using Core.ViewModels;
using Core;
using Microsoft.AspNetCore.Identity;
using Core.Services;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork<Employee> _employee;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeService(IUnitOfWork<Employee> employee, UserManager<ApplicationUser> userManager)
        {
            _employee = employee;
            _userManager = userManager;
        }

        public async Task<Employee> Create(SaveEmployeeResourceVM newModel)
        {
            var user = new ApplicationUser
            {
                Email = newModel.Email,
                FirstName = newModel.FirstName,
                LastName = newModel.LastName,
                PhoneNumber = newModel.PhoneNumber,
                FatherName = newModel.FatherName,
                MotherName = newModel.MotherName,
                SpouseName = newModel.SpouseName,
                DOB = newModel.DOB,
                GenderId = newModel.GenderId,
                Image = newModel.Base64,
                MiddleName = newModel.MiddleName,
                UserName = newModel.PhoneNumber,
                NID = newModel.NID,
                FullName = newModel.FirstName + " " + (!String.IsNullOrEmpty(newModel.MiddleName) ? newModel.MiddleName + " " + newModel.LastName : newModel.LastName),

            };
            var result = await _userManager.CreateAsync(user, "12345678");
            if (result.Succeeded)
            {
                var employee = new Employee
                {
                    Designation = newModel.Designation,
                    UserId = user.Id,
                    JoinDate = newModel.JoinDate,
                };
                await _employee.Entity.AddAsync(employee);
                await _employee.CommitAsync();
                return employee;
            }
            throw new Exception(result.Errors.First().Description);
        }

        public async Task<Employee> SingleOrDefaultAsync(Guid id) => await _employee.Entity.SingleOrDefaultAsync(id);

        public async Task<EmployeeResourceVM> SingleOrDefaultAndSelectAsync(Guid id) => await _employee.Entity.SingleOrDefaultAndSelectAsync(
            it => new EmployeeResourceVM
            {
                Designation = it.Designation,
            },
            it => it.Id == id
            );

        public async Task Delete(Employee model)
        {
            _employee.Entity.Remove(model);
            await _employee.CommitAsync();
        }

        public async Task<IEnumerable<EmployeeOptionsResourceVM>> Get()
        {
            return await _employee.Entity.GetAndSelectAsync(it => new EmployeeOptionsResourceVM
            {
                EmployeeId = it.Id,
                Name = it.User.FullName,
            });
        }

        public async Task Update(Employee modelToBeUpdated, UpdateEmployeeResourceVM model)
        {
            modelToBeUpdated.Designation = model.Designation;
            await _employee.CommitAsync();
        }

        public Task<IEnumerable<Food>> CreateRange(IEnumerable<Food> newModels)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetEmployeeVM>> GetAll()
        {

            return await _employee.Entity.GetAndSelectAsync(it => new GetEmployeeVM
            {
                Id = it.Id,
                Designation = it.Designation,
                JoinDate = it.JoinDate.ToString("D"),
                AmountSold = it.AmountSold,
                FullName = it.User.FullName,
                Email = it.User.Email,
                Phone = it.User.PhoneNumber,
                Image = it.User.Image,
            });
        }

        public async Task<IEnumerable<EmployeeOptionsResourceVM>> NonAssignedAsync(int tableId)
        {
            return await _employee.Entity.GetAndSelectAsync(
            it => new EmployeeOptionsResourceVM
            {

                EmployeeId = it.Id,
                Name = it.User.FullName,
            },
            it => !it.EmployeeTables.Any(et => et.TableId == tableId)
            );
        }


    }
}
