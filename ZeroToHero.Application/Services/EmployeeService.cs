using AutoMapper;
using System.Net;
using ZeroToHero.Application.Common.DTOs.EmployeeDtos;
using ZeroToHero.Application.Common.Exceptions;
using ZeroToHero.Application.Common.Helpers;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Application.Common.Utils;
using ZeroToHero.Application.Common.Extentions;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Application.Services;

public class EmployeeService(IUnitOfWork unitOfWork,
                            IMapper mapper) : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddEmployeeDto dto)
    {
        var employee = _mapper.Map<Employee>(dto);
        await _unitOfWork.Employes.CreateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _unitOfWork.Employes.GetByIdAsync(id);
        if (employee is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Employee Not Found");
        await _unitOfWork.Employes.DeleteAsync(employee);
    }

    public async Task<List<EmployeeDto>> GetAllAsync(PaginationParams @params)
    {
        var employees = (await _unitOfWork.Employes.GetAllAsync()).ToPagedListAsync(@params).Result;

        return employees.Select(p => _mapper.Map<EmployeeDto>(p)).ToList();
    }

    public async Task<EmployeeDto> GetByIdAsync(int id)
    {
        var employee = await _unitOfWork.Employes.GetByIdAsync(id);
        if (employee is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Employee not found");
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> GetByEmailAsync(string email)
    {
        var employee = await _unitOfWork.Employes.GetByEmailAsync(email);
        if (employee is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Employee not found");
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> GetByPhoneAsync(string phone)
    {
        var employee = await _unitOfWork.Employes.GetByPhoneAsync(phone);
        if (employee is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Employee not found");
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<IEnumerable<EmployeeDto>> GetByNameAsync(string name)
    {
        var employees = await _unitOfWork.Employes.GetByNameAsync(name);
        return employees.Select(x => _mapper.Map<EmployeeDto>(x)).ToList();
    }

    public async Task UpdateAsync(AddEmployeeDto dto)
    {
        var employee = await _unitOfWork.Employes.GetByIdAsync(HttpContextHelper.EmployeeId);
        if (employee is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Employee Not Found");
        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Email = dto.Email;
        employee.Phone = dto.Phone;
        employee.Role = dto.Role;
        await _unitOfWork.Employes.UpdateAsync(employee);
    }
}
