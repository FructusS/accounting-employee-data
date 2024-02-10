using AccountingEmployeeData.Data.Entities;
using AccountingEmployeeData.Domain.Models;

namespace AccountingEmployeeData.Application.Extensions;

public static class EmployeeExtension
{
    public static Employee ToEmployee(this EmployeeEntity entity)
    {
        return new Employee
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Patronymic = entity.Patronymic,
            Birthday = entity.Birthday,
            Address = entity.Address,
            Department = entity.Department,
            Description = entity.Description
        };
    }
}