using AccountingEmployeeData.Domain.Models;
using Prism.Events;

namespace AccountingEmployeeData.Desktop.Events;

internal class NavigateToCreateEmployeeEvent : PubSubEvent
{
    
}
internal class NavigateToEmployeeListEvent : PubSubEvent
{
}

internal class NavigateToEditEmployeeEvent : PubSubEvent<Employee>
{
}