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

public class EmployeeListViewModel : BaseViewModel
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

    public EmployeeListViewModel()
    { 
        LoadEmployeeList();
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