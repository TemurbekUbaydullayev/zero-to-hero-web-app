using ZeroToHero.Application.Common.DTOs.EmployeeDtos;
using ZeroToHero.Application.Common.Utils;

namespace ZeroToHero.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllAsync(PaginationParams @params);
    Task<EmployeeDto> GetByIdAsync(int id);
    Task<EmployeeDto> GetByEmailAsync(string email);
    Task<EmployeeDto> GetByPhoneAsync(string phone);
    Task<IEnumerable<EmployeeDto>> GetByNameAsync(string name);
    Task CreateAsync(AddEmployeeDto dto);
    Task UpdateAsync(AddEmployeeDto dto);
    Task DeleteAsync(int id);
}
