using AccountingEmployeeData.Domain.Models;

namespace AccountingEmployeeData.Application;

public class EmployeeService
{
    private EmployeeRepository _repository;
    public EmployeeService(EmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Employee>> GetList()
    {
        return await _repository.GetList();
    }

    public async Task<Employee> Get(Guid id)
    {
        return await _repository.Get(id);
    }

    public async Task<Guid> Update(Guid id, EmployeeDto employeeDto)
    {
        return await _repository.Update(id, employeeDto);
    }


    public async Task<Guid> Create(EmployeeDto employeeDto)
    {
        return await _repository.Create(employeeDto);
    }
    
    public async Task<Guid> Delete(Guid id)
    {
        return await _repository.Delete(id);
    }

}