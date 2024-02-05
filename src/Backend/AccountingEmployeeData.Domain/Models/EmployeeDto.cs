namespace AccountingEmployeeData.Domain.Models;

public class EmployeeDto
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Patronymic { get; set; }
    
    public DateOnly Birthday { get; set; }

    public string Address { get; set; }

    public string Department { get; set; }
    public string Description { get; set; }
}