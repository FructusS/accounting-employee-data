using System;
using System.Net.Http.Json;
using AccountingEmployeeData.Desktop.Events;
using AccountingEmployeeData.Desktop.Services;
using AccountingEmployeeData.Domain.Models;
using Prism.Commands;
using Prism.Events;

namespace AccountingEmployeeData.Desktop.ViewModels;

public class EmployeeViewModel : BaseViewModel
{
    private Employee _employee;

    public Employee Employee
    {
        get { return _employee; }
        set
        {
            _employee = value;
            OnPropertyChanged();
        }
    }

    public DelegateCommand SaveEmployeeCommand { get; private set; }
    private IEventAggregator _eventAggregator;

    public EmployeeViewModel(IEventAggregator aggregator)
    {
        _eventAggregator = aggregator;
        _employee = new Employee();
        SaveEmployeeCommand = new DelegateCommand(CreateEmployeeAsync);
    }

    public EmployeeViewModel(IEventAggregator aggregator, Employee employee)
    {
        _eventAggregator = aggregator;
        _employee = employee;
        SaveEmployeeCommand = new DelegateCommand(EditEmployeeAsync);
    }

    private async void EditEmployeeAsync()
    {
        try
        {
            var response = await HttpService.GetHttpClient().PutAsync($"Employee/{_employee.Id}", JsonContent.Create(_employee));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                _eventAggregator.GetEvent<NavigateToEmployeeListEvent>().Publish();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async void CreateEmployeeAsync()
    {
        try
        {
            var response = await HttpService.GetHttpClient().PostAsync("Employee", JsonContent.Create(_employee));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                _eventAggregator.GetEvent<NavigateToEmployeeListEvent>().Publish();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}