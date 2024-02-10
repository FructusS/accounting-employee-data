using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingEmployeeData.Desktop.Events;
using AccountingEmployeeData.Desktop.Services;
using AccountingEmployeeData.Domain.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;

namespace AccountingEmployeeData.Desktop.ViewModels;

public class EmployeeListViewModel : BaseFormViewModel
{

    private List<Employee> _employeeList;

    public List<Employee> EmployeeList
    {
        get => _employeeList;
        set
        {
            _employeeList = value;
            OnPropertyChanged();
        }
    }

    private readonly IEventAggregator _eventAggregator;
    public DelegateCommand<object> DeleteEmployeeCommand { get; private set;}
    public DelegateCommand<object> EditEmployeeCommand { get; private set;}
    public DelegateCommand OnNavigateToCreateEmployeeCommand { get; private set;}
    
    
    public EmployeeListViewModel(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        GetEmployeeListAsync();
        DeleteEmployeeCommand = new DelegateCommand<object>(DeleteEmployeeAsync);
        EditEmployeeCommand = new DelegateCommand<object>(OnNavigateToEditEmployee);
        OnNavigateToCreateEmployeeCommand = new DelegateCommand(OnNavigateToCreateEmployee);
    }

    private void OnNavigateToEditEmployee(object obj)
    {
        if (obj is Employee employee)
        {
            _eventAggregator.GetEvent<NavigateToEditEmployeeEvent>().Publish(employee);
        }
        else
        {
            throw new Exception($"{obj} is not Employee");
        }
    }

    private void OnNavigateToCreateEmployee()
    {
        _eventAggregator.GetEvent<NavigateToCreateEmployeeEvent>().Publish();
    }
    private async void DeleteEmployeeAsync(object id)
    {
        
        try
        {
            var response = await HttpService.GetHttpClient().DeleteAsync($"Employee/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                await GetEmployeeListAsync();
            }
            else
            { 
       
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task GetEmployeeListAsync()
    {
        try
        {
            var response = await HttpService.GetHttpClient().GetAsync("Employee");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var employeeList = JsonConvert.DeserializeObject<List<Employee>>(content);
                EmployeeList = employeeList;
            }
            else
            { 
                // TODO сделать норм вывод ошибки и отображение прогресс бара
                Console.Write(content);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}