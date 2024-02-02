using AccountingEmployeeData.Application.Exceptions;
using AccountingEmployeeData.Application.Extensions;
using AccountingEmployeeData.Data;
using AccountingEmployeeData.Data.Entities;
using AccountingEmployeeData.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingEmployeeData.Application;

public class EmployeeRepository
{

    private readonly ApplicationContext _context;
    
    public EmployeeRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Employee>> GetList()
    {
        return await _context.Employees.Select(x => x.ToEmployee()).ToListAsync();
    }

    public async Task<Guid> Create(EmployeeDto employeeDto)
    {
        var employee = new EmployeeEntity
        {
            Id = Guid.NewGuid(),
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Patronymic = employeeDto.Patronymic,
            Birthday = employeeDto.Birthday,
            Address = employeeDto.Address,
            Department = employeeDto.Department,
            Description = employeeDto.Description
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return employee.Id;
    }
    
    
    public async Task<Employee> Get(Guid id)
    {
        var employeeEntity = await _context.Employees.FindAsync(id);
        if (employeeEntity == null)
        {
            throw new NotFoundException($"{nameof(Employee)} not found");
        }
        return employeeEntity.ToEmployee();
    }

    public async Task<Guid> Update(Guid id, EmployeeDto employeeDto)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            throw new NotFoundException($"{nameof(Employee)} not found");
        }

        await _context.Employees
            .ExecuteUpdateAsync(e => e
                .SetProperty(p => p.Birthday, p => employeeDto.Birthday)
                .SetProperty(p => p.FirstName, p => employeeDto.FirstName)
                .SetProperty(p => p.LastName, p => employeeDto.LastName)
                .SetProperty(p => p.Department, p => employeeDto.Department)
                .SetProperty(p => p.Address, p => employeeDto.Address)
                .SetProperty(p => p.Description, p => employeeDto.Description)
                .SetProperty(p => p.Patronymic, p => employeeDto.Patronymic)
            );
        return id;
    }


    public async Task<Guid> Delete(Guid id)
    {
       await _context.Employees.Where(x=> x.Id == id).ExecuteDeleteAsync();
       return id;
    }
}