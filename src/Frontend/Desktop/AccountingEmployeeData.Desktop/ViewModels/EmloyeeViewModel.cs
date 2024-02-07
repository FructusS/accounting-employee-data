using AccountingEmployeeData.Domain.Models;
using Prism.Events;

namespace AccountingEmployeeData.Desktop.ViewModels;

public class EmployeeViewModel : BaseViewModel
{
    public EmployeeViewModel(IEventAggregator aggregator)
    {
        
    }
    
    public EmployeeViewModel(IEventAggregator aggregator, Employee employee)
    {
        
    }
}